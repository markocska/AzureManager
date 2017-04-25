using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureManagementLib.ModelView;
using AzureManagementLib.Services;

namespace AzureManagementLib
{

    public class SqlServerService : ISqlServerService
    {

        protected static IAzure AuthenticatedAzure { get; private set; }

        PagedList<ISqlServer> sqlServers;

        public SqlServerService(IAzure azure)
        {
            AuthenticatedAzure = azure;
        }

        public SqlServerService()
        {
           // AuthenticatedAzure = AuthenticationManager.
        }

        //private static SqlServerModel ISqlServerConvert(ISqlServer sqlServer)
        //{
            
        //    return new SqlServerModel(sqlServer);
        //}


       public async Task<IList<SqlServerModel>> GetResourcesAsync()
        {
            var returnList = new List<SqlServerModel>();

            sqlServers =
              await Task.Run(() => { return AuthenticatedAzure.SqlServers.List(); })
                  .ConfigureAwait(false);

            foreach (var sqlServer in sqlServers)
            {
                returnList.Add(new SqlServerModel(sqlServer));
            }
            

            return returnList;
        }


    }
}
