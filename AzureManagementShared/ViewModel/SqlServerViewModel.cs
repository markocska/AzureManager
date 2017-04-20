using AzureManagementLib.ModelView;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureManagementShared
{
    public class SqlServerViewModel : AzureViewModelBase
    {
        SqlServerModel sqlServer;

        public SqlServerViewModel(SqlServerModel sqlServerModel)
            :base(sqlServerModel)
        {
            sqlServer = sqlServerModel;
        }

       public string Version { get { return sqlServer.Version; } }
       
    }
}
