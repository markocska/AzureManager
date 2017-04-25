using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Resources;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.Azure.Management.KeyVault.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Rest;
using Microsoft.Rest.Azure.Authentication;
using static Microsoft.Azure.Management.Resource.Fluent.Core.RestClient;
using Microsoft.Rest.TransientFaultHandling;
using Microsoft.Azure.Management.Sql.Fluent.Models;

namespace AzureManagementLib
{
    public static class AuthenticationManager
    {
        private static string TenantId { get; }
        private static string AccesToken { get; }
        private static string Authority { get; set; } = "https://login.microsoftonline.com/common/";
        private static string AzureResourceManagement { get; } = "https://management.azure.com/";
        private static string Graph { get; } = "https://graph.windows.net";
        private static string ClientId { get; set; } = "48562591-a97e-4d68-b550-ff089a314bc0";

        private static Uri RedirectUri { get; } = new Uri("https://AzureManager");

        public static IAzure AuthenticatedAzure { get; private set; } = null;

        //getting the access token for a given Microsoft resource API
        private static async Task<Dictionary<string, string>> GetAccessTokenAsync(string resourceApi,PlatformParameters platformParams)
        {
            try
            {
                using (var loginClient = new HttpClient())
                {
                    AuthenticationContext authContex = new AuthenticationContext(Authority);
                    // var param = new PlatformParameters();
                    authContex.ExtendedLifeTimeEnabled = false;

                    var authResult = await authContex.AcquireTokenAsync(AzureResourceManagement, ClientId, RedirectUri,platformParams).ConfigureAwait(false);


                    var results = new Dictionary<string, string>();
                    results.Add("token", authResult.AccessToken);
                    results.Add("tenant", authResult.TenantId);


                    return results;
                }
            } catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public static async Task<AzureResourceManager> Authenticate(PlatformParameters platformParams)
        {
            
            try { 
            Dictionary<string, string> authDataDict = await GetAccessTokenAsync(AzureResourceManagement, platformParams).ConfigureAwait(false);

            ServiceClientCredentials serviceClientCred = new TokenCredentials(authDataDict["token"]);
           

            var restClientBuilder = RestClient.Configure().WithEnvironment(AzureEnvironment.AzureGlobalCloud);

             

            var restClient = restClientBuilder.WithEnvironment(AzureEnvironment.AzureGlobalCloud).WithCredentials(serviceClientCred)
                .WithRetryPolicy(new RetryPolicy(new HttpStatusCodeErrorDetectionStrategy(),1))
                .WithEnvironment(AzureEnvironment.AzureGlobalCloud).WithDelegatingHandler(new HttpLoggingDelegatingHandler()).Build();
                

            var lucuka = authDataDict["tenant"];
    

                var azure = Azure.Authenticate(restClient, lucuka);
                var subs = azure.Subscriptions.List();

                var azure1 = Azure.Authenticate(restClient, lucuka).WithSubscription(subs.First().SubscriptionId);


                // var list = azure1.SqlServers.List()[1];
                //        var subs=azure.Subscriptions;
                AuthenticationManager.AuthenticatedAzure = azure1;

                return new AzureResourceManager(azure1);
            }
             catch (Exception ex)
            {
                throw ex;
            }

            
        }
    }
}
