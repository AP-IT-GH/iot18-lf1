van@Azure:\~\$ az group create --name IoT\_labfarm --location "West
Europe" { "id":
"/subscriptions/d4aba205-a7c8-4197-89fa-3313897eed68/resourceGroups/IoT\_labfarm",
"location": "westeurope", "managedBy": null, "name": "IoT\_labfarm",
"properties": { "provisioningState": "Succeeded" }, "tags": null }

admin : labfarmadmin password: ditiseenIOTwachtwoord99

van@Azure:\~\$ az sql server create --name IoTlabfarm --resource-group
IoT\_labfarm --location "West Europe" --admin-user labfarmadmin
--admin-password ditiseenIOTwachtwoord99 { "administratorLogin":
"labfarmadmin", "administratorLoginPassword": null,
"fullyQualifiedDomainName": "iotlabfarm.database.windows.net", "id":
"/subscriptions/d4aba205-a7c8-4197-89fa-3313897eed68/resourceGroups/IoT\_labfarm/providers/Microsoft.Sql/servers/iotlabfarm",
"identity": null, "kind": "v12.0", "location": "westeurope", "name":
"iotlabfarm", "resourceGroup": "IoT\_labfarm", "state": "Ready", "tags":
null, "type": "Microsoft.Sql/servers", "version": "12.0" }

van@Azure:\~\$ az sql server firewall-rule create --resource-group
IoT\_labfarm --server iotlabfarm --name AllowYourIp --start-ip-address
0.0.0.0 --end-ip-address0.0.0.0 { "endIpAddress": "0.0.0.0", "id":
"/subscriptions/d4aba205-a7c8-4197-89fa-3313897eed68/resourceGroups/IoT\_labfarm/providers/Microsoft.Sql/servers/iotlabfarm/firewallRules/AllowYourIp",
"kind": "v12.0", "location": "West Europe", "name": "AllowYourIp",
"resourceGroup": "IoT\_labfarm", "startIpAddress": "0.0.0.0", "type":
"Microsoft.Sql/servers/firewallRules" }

van@Azure:\~\$ az sql db create --resource-group IoT\_labfarm --server
iotlabfarm --name coreDB --service-objective S0 { "catalogCollation":
"SQL\_Latin1\_General\_CP1\_CI\_AS", "collation":
"SQL\_Latin1\_General\_CP1\_CI\_AS", "createMode": null, "creationDate":
"2018-11-05T12:51:08.790000+00:00", "currentServiceObjectiveName": "S0",
"currentSku": { "capacity": 10, "family": null, "name": "Standard",
"size": null, "tier": "Standard" }, "databaseId":
"bd580594-dc37-4fee-9dde-86fb0eaf0d67", "defaultSecondaryLocation":
"northeurope", "earliestRestoreDate":
"2018-11-05T13:21:08.790000+00:00", "edition": "Standard",
"elasticPoolId": null, "elasticPoolName": null, "failoverGroupId": null,
"id":
"/subscriptions/d4aba205-a7c8-4197-89fa-3313897eed68/resourceGroups/IoT\_labfarm/providers/Microsoft.Sql/servers/iotlabfarm/databases/coreDB",
"kind": "v12.0,user", "licenseType": null, "location": "westeurope",
"longTermRetentionBackupResourceId": null, "managedBy": null,
"maxLogSizeBytes": null, "maxSizeBytes": 268435456000, "name": "coreDB",
"readScale": "Disabled", "recoverableDatabaseId": null,
"recoveryServicesRecoveryPointId": null,
"requestedServiceObjectiveName": "S0", "resourceGroup": "IoT\_labfarm",
"restorableDroppedDatabaseId": null, "restorePointInTime": null,
"sampleName": null, "sku": { "capacity": 10, "family": null, "name":
"Standard", "size": null, "tier": "Standard" },
"sourceDatabaseDeletionDate": null, "sourceDatabaseId": null, "status":
"Online", "tags": null, "type": "Microsoft.Sql/servers/databases",
"zoneRedundant": false } van@Azure:\~\$

connection string:
Server=tcp:iotlabfarm.database.windows.net,1433;Database=coreDB;User
ID=labfarmadmin;Password=ditiseenIOTwachtwoord99;Encrypt=true;Connection
Timeout=30;

van@Azure:\~\$ az webapp deployment user set --user-name sS096257
--password Ditiseenuniekwachtwoord99 { "id": null, "kind": null, "name":
"web", "publishingPassword": null, "publishingPasswordHash": null,
"publishingPasswordHashSalt": null, "publishingUserName": "sS096257",
"scmUri": null, "type": "Microsoft.Web/publishingUsers/web" }

Azure deployment user: user: sS096257 wachtwoord:
Ditiseenuniekwachtwoord99

van@Azure:\~\$ az appservice plan create --name labfarmServicePlan
--resource-group IoT\_labfarm --sku FREE { "adminSiteName": null,
"freeOfferExpirationTime": null, "geoRegion": "West Europe",
"hostingEnvironmentProfile": null, "hyperV": null, "id":
"/subscriptions/d4aba205-a7c8-4197-89fa-3313897eed68/resourceGroups/IoT\_labfarm/providers/Microsoft.Web/serverfarms/labfarmServicePlan",
"isSpot": false, "isXenon": false, "kind": "app", "location": "West
Europe", "maximumNumberOfWorkers": 1, "name": "labfarmServicePlan",
"numberOfSites": 0, "perSiteScaling": false, "provisioningState":
"Succeeded", "reserved": false, "resourceGroup": "IoT\_labfarm", "sku":
{ "capabilities": null, "capacity": 0, "family": "F", "locations": null,
"name": "F1", "size": "F1", "skuCapacity": null, "tier": "Free" },
"spotExpirationTime": null, "status": "Ready", "subscription":
"d4aba205-a7c8-4197-89fa-3313897eed68", "tags": null,
"targetWorkerCount": 0, "targetWorkerSizeId": 0, "type":
"Microsoft.Web/serverfarms", "workerTierName": null }

van@Azure:\~\$ az webapp create --resource-group IoT\_labfarm --plan
labfarmServicePlan --name labfarmWebApp --deployment-local-git Local git
is configured with url of
'https://sS096257@labfarmwebapp.scm.azurewebsites.net/labfarmWebApp.git'
{ "availabilityState": "Normal", "clientAffinityEnabled": true,
"clientCertEnabled": false, "cloningInfo": null, "containerSize": 0,
"dailyMemoryTimeQuota": 0, "defaultHostName":
"labfarmwebapp.azurewebsites.net", "deploymentLocalGitUrl":
"https://sS096257@labfarmwebapp.scm.azurewebsites.net/labfarmWebApp.git",
"enabled": true, "enabledHostNames": [
"labfarmwebapp.azurewebsites.net", "labfarmwebapp.scm.azurewebsites.net"
], "ftpPublishingUrl":
"ftp://waws-prod-am2-231.ftp.azurewebsites.windows.net/site/wwwroot",
"hostNameSslStates": [ { "hostType": "Standard", "ipBasedSslResult":
null, "ipBasedSslState": "NotConfigured", "name":
"labfarmwebapp.azurewebsites.net", "sslState": "Disabled", "thumbprint":
null, "toUpdate": null, "toUpdateIpBasedSsl": null, "virtualIp": null },
{ "hostType": "Repository", "ipBasedSslResult": null, "ipBasedSslState":
"NotConfigured", "name": "labfarmwebapp.scm.azurewebsites.net",
"sslState": "Disabled", "thumbprint": null, "toUpdate": null,
"toUpdateIpBasedSsl": null, "virtualIp": null } ], "hostNames": [
"labfarmwebapp.azurewebsites.net" ], "hostNamesDisabled": false,
"hostingEnvironmentProfile": null, "httpsOnly": false, "hyperV": null,
"id":
"/subscriptions/d4aba205-a7c8-4197-89fa-3313897eed68/resourceGroups/IoT\_labfarm/providers/Microsoft.Web/sites/labfarmWebApp",
"identity": null, "isDefaultContainer": null, "isXenon": false, "kind":
"app", "lastModifiedTimeUtc": "2018-11-05T12:59:35.736666", "location":
"West Europe", "maxNumberOfWorkers": null, "name": "labfarmWebApp",
"outboundIpAddresses":
"51.137.106.13,23.97.143.58,104.46.35.14,40.91.195.130,104.46.56.115",
"possibleOutboundIpAddresses":
"51.137.106.13,23.97.143.58,104.46.35.14,40.91.195.130,104.46.56.115,23.97.138.9,168.63.98.31,51.144.82.49",
"repositorySiteName": "labfarmWebApp", "reserved": false,
"resourceGroup": "IoT\_labfarm", "scmSiteAlsoStopped": false,
"serverFarmId":
"/subscriptions/d4aba205-a7c8-4197-89fa-3313897eed68/resourceGroups/IoT\_labfarm/providers/Microsoft.Web/serverfarms/labfarmServicePlan",
"siteConfig": null, "slotSwapStatus": null, "state": "Running",
"suspendedTill": null, "tags": null, "targetSwapSlot": null,
"trafficManagerHostNames": null, "type": "Microsoft.Web/sites",
"usageState": "Normal" }

van@Azure:\~\$ az webapp config connection-string set --resource-group
IoT\_labfarm --name labfarmWebApp --settings
MyDbConnection='Server=tcp:iotlabfarm.database.windows.net,1433;Database=coreDB;User
ID=labfarmadmin;Password=ditiseenIOTwachtwoord99;Encrypt=true;Connection
Timeout=30;' --connection-string-type SQLServer { "MyDbConnection": {
"type": "SQLServer", "value":
"Server=tcp:iotlabfarm.database.windows.net,1433;Database=coreDB;User
ID=labfarmadmin;Password=ditiseenIOTwachtwoord99;Encrypt=true;Connection
Timeout=30;" } }
