/* Imports */
import { keyValue } from '../types.bicep'

/* Parameters */

// General parameters
param projectName string
param location string
param locationShortName string
param environment string
param deploymentId string

// App Configuration parameters
param keyValues keyValue[] = []

/* Variables */
var appConfigurationStoreName = 'aco-${projectName}-${environment}-${locationShortName}'

/* Resources */
module appConfigurationStore 'br/public:avm/res/app-configuration/configuration-store:0.2.1' = {
  name: '${deploymentId}-${appConfigurationStoreName}-deployment'
  params: {
    name: appConfigurationStoreName
    location: location
    managedIdentities: {
      systemAssigned: true
      }
    disableLocalAuth: false
    enablePurgeProtection: environment == 'dev' ? false : true
    keyValues: [for keyValue in keyValues: {
        name: keyValue.name
        value: keyValue.value
        contentType: keyValue.contentType
      }
    ]
  }
}

/* Outputs */
output appConfigurationStoreSystemManagedIdentityId string = appConfigurationStore.outputs.systemAssignedMIPrincipalId
