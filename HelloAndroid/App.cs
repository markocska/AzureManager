using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AzureManagementShared;
using GalaSoft.MvvmLight.Views;
using AzureManagementShared.ViewModel;
using AzureManagementLib.ModelView;

namespace HelloAndroid
{
    public static class App
    {
        private static ViewModelLocator _locator;
        private static ViewModelLocator Locator
        {
            get
            {
                var nav = new NavigationService();
                nav.Configure(
                        ViewModelLocator.sqlServerListPageKey,
                         typeof(AzureListViewModel<SqlServerModel,SqlServerViewModel>));
            }
        }
    }
}