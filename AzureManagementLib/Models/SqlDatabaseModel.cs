using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Sql.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib.Models
{
    public class SqlDatabaseModel : AzureResource<ISqlDatabase>
    {
        internal ISqlDatabase sqlDatabase;

        public string Status {get { return sqlDatabase.Status; }  }

        public SqlDatabaseModel(ISqlDatabase sqlDatabase): 
            base(sqlDatabase)
        {
            this.sqlDatabase = sqlDatabase;
        }
    }
}
