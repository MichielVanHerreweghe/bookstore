
// Service Bus Topic Types
@export()
type topic = {
  name: string
  subscriptions: subscription[]
}

@export()
type subscription = {
  name: string
}

// Key Vault Types
@export()
@secure()
type secret = {
  name: string
 value: string
}

// App Configuration Store Types
@export()
type keyValue = {
  name: string
  label: string?
  value: string
  contentType: string?
}

// Role Assignment Types
@export()
type roleAssignment = {
  name: string
  properties: {
    roleDefinitionId: string
    principalId: string
    principalType: ('Device' | 'ForeignGroup' | 'Group' | 'ServicePrincipal' | 'User')
  }
}
