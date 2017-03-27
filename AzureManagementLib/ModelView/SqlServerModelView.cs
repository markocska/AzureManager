using Microsoft.Azure.Management.Sql.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib.ModelView
{
    public class SqlServerModelView
    {
        internal ISqlServer SqlServer { get; set; }
        public string ServerName { get { return SqlServer.Name; }  }
        public string ResourceGroupName { get { return SqlServer.ResourceGroupName; } }
        public string Status { get { return SqlServer.Version; } }
        public string Location { get { return SqlServer.RegionName; } }
        public string SubscriptionName { get { return SqlServer.AdministratorLogin; } }

        internal SqlServerModelView(ISqlServer sqlServer)
        {
            this.SqlServer = sqlServer;
        }
    }
}
