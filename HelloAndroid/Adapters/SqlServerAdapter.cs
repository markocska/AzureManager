using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using AzureManagementLib.ModelView;
using HelloAndroid.ViewHolders;

namespace HelloAndroid.Adapters
{
    public class SqlServerAdapter : AzureItemAdapter<SqlServerModelView>
    {
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            SqlServerViewHolder vh = holder as SqlServerViewHolder;

            vh.Location.Text = AzureItemViews[position].Location;
            vh.ServerName.Text = AzureItemViews[position].ServerName;
            vh.ResourceGroupName.Text = AzureItemViews[position].ResourceGroupName;
            vh.SubscriptionName.Text = AzureItemViews[position].SubscriptionName;

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                Inflate(Resource.Layout.SqlServerLayout, parent, false);

            SqlServerViewHolder sqlVh = new SqlServerViewHolder(itemView);
            return sqlVh;
        }

        public SqlServerAdapter(List<SqlServerModelView> sqlServerList) : base(sqlServerList)
        {
            
        }
    }
}