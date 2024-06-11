/* Imports */

/* Parameters */

// General parameters
param projectName string
param location string
param locationShortName string
param environment string

// Service Bus parameters
@allowed([
  'Basic'
  'Premium'
  'Standard'
])
param serviceBusSkuName string

/* Variables */
var serviceBusNamespace = 'sb-${projectName}-${environment}-${locationShortName}'

/* Resources */
resource serviceBus 'Microsoft.ServiceBus/namespaces@2022-10-01-preview' = {
  name: serviceBusNamespace
  location: location
  sku: {
    name: serviceBusSkuName
  }
}

/* Outputs */
output serviceBusNamespace string = serviceBus.name
output serviceBusConnectionstring string = listKeys('${serviceBus.id}/AuthorizationRules/RootManageSharedAccessKey', serviceBus.apiVersion).primaryConnectionString
