using AzureManagementLib;
using AzureManagementLib.Services;
using AzureManagementShared.ViewModel;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureManagementShared
{
    public class ViewModelLocator
    {

        private static IDictionary<string, string> pages;

        public static readonly string sqlDatabaseListPageKey = "SqlDatabaseListPage";
        public static readonly string sqlDatabaseDetailsPageKey = "SqlDatabaseDetailsPage";

        public static readonly string sqlServerListPageKey = "SqlServerListPage";
        public static readonly string sqlServerDetailsPageKey = "SqlServerDetailsPage";

        public MainViewModel Main
        {
            get
            {
               return  ServiceLocator.Current.GetInstance<MainViewModel>();             
            }
        }

        public static string searchPageByViewModelType(Type type)
        {
            return pages[type.FullName] ;
        }

       public static bool PageExists(string page)
        {
            return pages.Values.Contains(page);
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<ISqlServerService, SqlServerService>();

            SimpleIoc.Default.Register<MainViewModel>();

            pages = new Dictionary<string, string>
            {
                { typeof(SqlDatabaseViewModel).FullName,sqlDatabaseListPageKey },
                { typeof(SqlServerViewModel).FullName,sqlServerListPageKey}
            };
        }

    }
}
