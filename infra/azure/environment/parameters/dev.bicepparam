using '../main.bicep'

// General
param projectName = 'bookstore'
param location = 'westeurope'
param locationShortName = 'weu'
param environment = 'dev'
param daprPrincipalId = '3f9fb3e4-5f85-4aad-b496-4545fdc41495'

// Service Bus
param serviceBusSkuName = 'Standard'

// Service Bus Topic
param serviceBusTopics = [
  {
    name: 'author'
    subscriptions: [
      {
        name: 'book-api'
      }
    ]
  }
]

// Key Vault
param keyVaultSku = 'standard'
