using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    public static class Auth
    {
        private static string TenantId { get; }
        private static string AccesToken { get; }
        private static string Authority { get; set; } = "https://login.microsoftonline.com/common/";
        private static string AzureResourceManagement { get; } = "https://management.core.windows.net/";
        private static string Graph { get; } = "https://graph.windows.net";
        private static string ClientId { get; set; } = "48562591-a97e-4d68-b550-ff089a314bc0";



            public  static Dictionary<string, string> GetAccessTokenAsync(string resourceApi)
        {
            using (var loginClient = new HttpClient())
            {
                AuthenticationContext authContex = new AuthenticationContext(Authority);

                var authResult =  authContex.AcquireTokenAsync(Graph, ClientId,new Uri("https://AzureManager"),new PlatformParameters(PromptBehavior.Always));

                var results = new Dictionary<string, string>();
                results.Add("token", authResult.Result.
                    AccessToken);
                results.Add("tenant", authResult.Result.TenantId);

                return results;
            }
        
    }
    }
}
