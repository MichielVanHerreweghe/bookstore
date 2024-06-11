using '../main.bicep'

// General
param projectName = 'bookstore'
param location = 'westeurope'
param locationShortName = 'weu'
param environment = 'dev'

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
