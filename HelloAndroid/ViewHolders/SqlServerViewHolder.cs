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
using Android.Support.V7.Widget;

namespace HelloAndroid.ViewHolders
{
   public class SqlServerViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; private set; }
        public TextView ServerName { get; private set; }
        public TextView ResourceGroupName { get; private set; }
        //public TextView Status { get; private set; }
        public TextView Location { get; private set; }
        public TextView SubscriptionName { get; private set; }



        public SqlServerViewHolder(View itemView): base(itemView)
        {
            Image = itemView.FindViewById<ImageView>(Resource.Id.sqlServerImage);
            ServerName = itemView.FindViewById<TextView>(Resource.Id.sqlServerName);
            ResourceGroupName = itemView.FindViewById<TextView>(Resource.Id.sqlResourceGroupName);
           // Status = itemView.FindViewById<TextView>(Resource.Id.sqlStatus);
            Location = itemView.FindViewById<TextView>(Resource.Id.sqlLocation);
            SubscriptionName = itemView.FindViewById<TextView>(Resource.Id.sqlSubscriptionName);
        }

      
    }
}