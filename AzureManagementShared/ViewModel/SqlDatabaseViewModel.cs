using System;
using System.Collections.Generic;
using System.Text;
using AzureManagementLib.Models;

namespace AzureManagementShared.ViewModel
{
    public class SqlDatabaseViewModel : AzureViewModelBase
    {
        SqlDatabaseModel sqlDatabase;
        public SqlDatabaseViewModel(SqlDatabaseModel sqlDatabase) : base(sqlDatabase)
        {
            this.sqlDatabase = sqlDatabase;
        }

        public string Status {get { return sqlDatabase.Status; } }
    }
}
