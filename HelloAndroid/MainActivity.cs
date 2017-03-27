using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AzureManagementLib;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Collections.Generic;
using System.Net.Http;
using Android.Support.V7.Widget;
using AzureManagementLib.ModelView;
using System.Threading.Tasks;
using System.Threading;
using HelloAndroid.Adapters;
//using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace HelloAndroid
{
    [Activity(Label = "Hello Android!", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        PlatformParameters platformParam;
        private AzureResourceManager azureResourceManager;
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager layoutManager;
        SqlServerAdapter sqlServerAdapter ;
        List<SqlServerModelView> sqlServerList;
        
       

        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);

            platformParam = new PlatformParameters(this, true);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.sqlServerRecyclerView);
            layoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(layoutManager);

            sqlServerAdapter = new SqlServerAdapter(sqlServerList);
            mRecyclerView.SetAdapter(sqlServerAdapter);

            Button optionsButton = FindViewById<Button>(Resource.Id.optionsButton);

            optionsButton.Click += async (object sender, EventArgs e) =>
            {
                //Dictionary<string,string> dict = await AuthenticationManager.GetAccessTokenAsync("lucu", platformParam);
                try
                {
                    
                    List<SqlServerModelView> sqlServersTask =  await azureResourceManager.SqlDbManager.GetSqlServersAsync().ConfigureAwait(false);
                    sqlServerAdapter.SqlServerViews = sqlServersTask;
                    
                }
                catch (Exception ex)
                {
                    string exc = ex.Message;
                }
            };

            ThreadPool.QueueUserWorkItem(o => LoginHandler());
            //   new Thread(new ThreadStart(async () => { await azureResourceManager = AzureResourceManager.Create(platformParam); }))  
            

        }

        public void LoginHandler()
        {

            AlertDialog.Builder alertBuilder = new AlertDialog.Builder(this);
            alertBuilder.SetTitle("Login")
                 .SetMessage("Please wait while logging in...")
                 .SetCancelable(false);

            AlertDialog dialog = null;
            RunOnUiThread(() => { dialog = alertBuilder.Show(); });
            try
            {          
                azureResourceManager = AzureResourceManager.Create(platformParam).Result;
            } catch (Exception e)
            {

            }
            finally
            {
                if (dialog != null)
                {
                    dialog.Dismiss();
                    dialog.Dispose();
                }
                if (alertBuilder != null)
                {
                    alertBuilder.Dispose();
                }
            }
            
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationAgentContinuationHelper.SetAuthenticationAgentContinuationEventArgs(requestCode, resultCode, data);
        }
    }
}

