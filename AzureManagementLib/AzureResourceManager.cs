using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace AzureManagementLib
{
    public class AzureResourceManager 
    {
        public IAzure AuthenticatedAzure { get; private set; }
        public SqlDatabaseManager SqlDbManager { get; private set; }

        private AzureResourceManager(IAzure authenticatedAzure)
        {
            AuthenticatedAzure = authenticatedAzure;
            SqlDbManager = new SqlDatabaseManager(AuthenticatedAzure);
           
        }

        public static async Task<AzureResourceManager> Create(PlatformParameters platformParams)
        {
            IAzure authenticatedAzure = await AuthenticationManager.Authenticate(platformParams);
            return new AzureResourceManager(authenticatedAzure);
        }

        public void changeSubscription()
        {

        }

        public void changeTenant()
        {

        }

      
    }
}
