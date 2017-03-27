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

namespace AzureManagementLib
{

    public class SqlDatabaseManager
    {

        public static IAzure AuthenticatedAzure { get; private set; }

        public SqlDatabaseManager(IAzure azure)
        {
            AuthenticatedAzure = azure;
        }

        private static SqlServerModelView ISqlServerConvert(ISqlServer sqlServer)
        {
            return new SqlServerModelView(sqlServer);
        }


       public async Task<List<SqlServerModelView>> GetSqlServersAsync()
        {
            var returnList = new List<SqlServerModelView>();

            PagedList<ISqlServer> sqlServers =
              await Task.Run(() => { return AuthenticatedAzure.SqlServers.List(); })
                  .ConfigureAwait(false);
            foreach (var sqlServer in sqlServers)
            {
                returnList.Add(ISqlServerConvert(sqlServer));
            }


            return returnList;
        }


    }
}
