using AzureManagementLib.Models;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Sql.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib.ModelView
{
    public class SqlServerModel : AzureResource<ISqlServer>
    {
        internal ISqlServer sqlServer;

        internal SqlServerModel(ISqlServer sqlServer) :
            base(sqlServer)
        {
            this.sqlServer = sqlServer;       
        }

        public string Version {get { return sqlServer.Version; } }
    }
}
