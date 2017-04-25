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
using AzureManagementShared.ViewModel;
using AzureManagementLib.Models;
using AzureManagementShared;
using AzureManagementLib.ModelView;

namespace HelloAndroid
{
    [Activity(Label = "Resource List")]
    public class ResourceListActivity<T,K> : Activity
        where T : IAzureResource
        where K : AzureViewModelBase
    {
        public AzureListViewModel<T,K> ResourceListViewModel
        {
            get;
            set;
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            // Create your application here
        }
    }
}