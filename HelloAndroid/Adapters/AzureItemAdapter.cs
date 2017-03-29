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
using AzureManagementLib.ModelView;
using Android.Support.V7.Widget;
using HelloAndroid.ViewHolders;

namespace HelloAndroid.Adapters
{
    public abstract class AzureItemAdapter<T> : RecyclerView.Adapter
    {

        public List<T> AzureItemViews { get; set; }

        public override int ItemCount
        {
            get
            {
                if (AzureItemViews != null)
                {
                    return AzureItemViews.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public  AzureItemAdapter(List<T> azureItemViews)
        {
            AzureItemViews = azureItemViews;
        }

        public AzureItemAdapter()
        {

        }

    }
}