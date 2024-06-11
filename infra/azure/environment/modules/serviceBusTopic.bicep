/* Imports */
import { subscription } from '../types.bicep'

/* Parameters */

// General parameters
param serviceBusNamespace string

// Service Bus Topic parameters
param topicName string

// Service Bus Subscription parameters
param subscriptions subscription[]

/* Resources */
resource serviceBus 'Microsoft.ServiceBus/namespaces@2022-10-01-preview' existing = {
  name: serviceBusNamespace
}

resource topic 'Microsoft.ServiceBus/namespaces/topics@2022-10-01-preview' = {
  name: topicName
  parent: serviceBus
}

resource subscriptionResources 'Microsoft.ServiceBus/namespaces/topics/subscriptions@2022-10-01-preview' = [ for subscription in subscriptions : {
    name: subscription.name
    parent: topic
  }
]
