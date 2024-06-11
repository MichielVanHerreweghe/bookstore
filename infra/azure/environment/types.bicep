
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

@export()
type roleAssignment = {
  name: string
  properties: {
    roleDefinitionId: string
    principalId: string
    principalType: ('Device' | 'ForeignGroup' | 'Group' | 'ServicePrincipal' | 'User')
  }
}
