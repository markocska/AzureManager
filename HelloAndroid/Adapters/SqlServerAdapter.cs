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
    public class SqlServerAdapter : RecyclerView.Adapter
    {
        // public event EventHandler<int> ItemClick;

        public List<SqlServerModelView> SqlServerViews { get; set; }

        public override int ItemCount
        {
            get
            {
                if (SqlServerViews != null)
                {
                    return SqlServerViews.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public SqlServerAdapter(List<SqlServerModelView> sqlServerList)
        {
            SqlServerViews = sqlServerList;
        }

        public SqlServerAdapter()
        {

        }

        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                Inflate(Resource.Layout.SqlServerLayout, parent, false);

            SqlServerViewHolder sqlVh = new SqlServerViewHolder(itemView);
            return sqlVh;
        }


        //void OnClick(int position)
        //{
        //    if (ItemClick != null)
        //    {
        //        ItemClick(this, position);
        //    }
        //}

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            SqlServerViewHolder vh = holder as SqlServerViewHolder;

            vh.Location.Text = SqlServerViews[position].Location;
            vh.ServerName.Text = SqlServerViews[position].ServerName;
            vh.ResourceGroupName.Text = SqlServerViews[position].ResourceGroupName;
            vh.SubscriptionName.Text = SqlServerViews[position].SubscriptionName;
        }
    }
}