targetScope = 'subscription'

/* Imports */
import { topic } from 'types.bicep'

/* Parameters */

// General parameters
param projectName string
param location string
param locationShortName string

@allowed([
  'dev'
  'uat'
  'prd'
])
param environment string
param deploymentId string = take(newGuid(), 8)
param daprPrincipalId string

// Service Bus parameters
@allowed([
  'Basic'
  'Premium'
  'Standard'
])
param serviceBusSkuName string

// Service Bus Topic parameters
param serviceBusTopics topic[]

// Key Vault parameters
@allowed([
  'standard'
  'premium'
])
param keyVaultSku string

/* Variables */
var resourceGroupName = 'rg-${projectName}-${environment}-${locationShortName}'

/* Resources */

// Resource Group
resource resourceGroup 'Microsoft.Resources/resourceGroups@2024-03-01' = {
  name: resourceGroupName
  location: location
}

// Service Bus
module serviceBus 'modules/serviceBus.bicep' = {
  scope: resourceGroup
  name: '${deploymentId}-servicBusNamespace-deployment'
  params: {
    projectName: projectName
    location: location
    locationShortName: locationShortName
    environment: environment
    serviceBusSkuName: serviceBusSkuName
  }
} 

// Service Bus Topics
module serviceBusTopicResources 'modules/serviceBusTopic.bicep' = [for topic in serviceBusTopics: {
    scope: resourceGroup
    name: '${deploymentId}-serviceBusTopic-${topic.name}-deployment'
    params: {
      serviceBusNamespace: serviceBus.outputs.serviceBusNamespace
       topicName: topic.name
       subscriptions: topic.subscriptions
    }
  }
]

// Key Vault
module keyVault 'modules/keyVault.bicep' = {
  scope: resourceGroup
  name: '${deploymentId}-keyVault-deployment'
  params: {
    projectName: projectName
    location: location
    locationShortName: locationShortName
    environment: environment
    deploymentId: deploymentId
    daprPrincipalId: daprPrincipalId
    keyVaultSku: keyVaultSku
    secrets: [
      {
        name: 'ConnectionStrings--ServiceBus'
        value: serviceBus.outputs.serviceBusConnectionstring
      }
    ]
    appConfigurationStoreSystemManagedIdentityId: appConfigurationStore.outputs.appConfigurationStoreSystemManagedIdentityId
  }
}

// App Configuration Store
module appConfigurationStore 'modules/appConfigurationStore.bicep' = {
  scope: resourceGroup
  name: '${deploymentId}-appConfigurationStore-deployment'
  params: {
    projectName: projectName
    location: location
    locationShortName: locationShortName
    environment: environment
    deploymentId: deploymentId
  }
}

module appConfigurationStoreKeyValues 'modules/appConfigurationStore.bicep' = {
  scope: resourceGroup
  name: '${deploymentId}-appConfigurationStore-keyValues-deployment'
  params: {
    projectName: projectName
    location: location
    locationShortName: locationShortName
    environment: environment
    deploymentId: deploymentId
    keyValues: [
      {
        name: 'ConnectionStrings:ServiceBus'
        value:  '{"uri":"${keyVault.outputs.keyVaultUri}secrets/ConnectionStrings--ServiceBus"}'
        contentType: 'application/vnd.microsoft.appconfig.keyvaultref+json;charset=utf-8'
      }
    ]
  }
}
