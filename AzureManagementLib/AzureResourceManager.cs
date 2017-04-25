using AzureManagementLib.Services;
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

        private SqlServerService _sqlServerService;
        public SqlServerService SqlServerService {
            get
            {
                return _sqlServerService
                    ?? new SqlServerService(AuthenticatedAzure);
            }
        }

        public AzureResourceManager(IAzure authenticatedAzure)
        {
            AuthenticatedAzure = authenticatedAzure;
           
        }

        //public T CreateService<T>() where T : IAzureService
        //{

        //}

        public void changeSubscription()
        {

        }

        public void changeTenant()
        {

        }

      
    }
}
