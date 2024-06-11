/* Imports */
import { secret } from '../types.bicep'

/* Parameters */

// General parameters
param projectName string
param location string
param locationShortName string
param environment string
param deploymentId string

// Key Vault parameters
@allowed([
  'standard'
  'premium'
])
param keyVaultSku string
param secrets secret[]

/* Variables */
var keyVaultName = 'kv-${projectName}-${environment}-${locationShortName}'

/* Resources */
module keyVault 'br/public:avm/res/key-vault/vault:0.6.1' = {
  name: '${deploymentId}-${keyVaultName}-deployment'
  params: {
    name: keyVaultName
    location: location
    sku: keyVaultSku
    enablePurgeProtection: environment == 'dev' ? false : true
    enableSoftDelete: environment == 'dev' ? false : true
    secrets: secrets
  }
}
