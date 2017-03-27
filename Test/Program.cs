using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Compute.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Rest;
using System.Net.Http;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using TestLib;

namespace Test
{
    class Program
    {
        private static string TenantId { get; }
        private static string AccesToken { get; }
        private static string Authority { get; set; } = "https://login.microsoftonline.com/common/";
        private static string AzureResourceManagement { get; } = "https://management.core.windows.net/";
        private static string Graph { get; } = "https://graph.windows.net";
        private static string ClientId { get; set; } = "48562591-a97e-4d68-b550-ff089a314bc0";

        private static Uri RedirectUri { get; } = new Uri("https://AzureManager");

        public async static Task<Dictionary<string, string>> GetAccessTokenAsync(string resourceApi)
        {
            using (var loginClient = new HttpClient())
            {
                AuthenticationContext authContex = new AuthenticationContext(Authority);

                var authResult = await authContex.AcquireTokenAsync(Graph, ClientId, new UserAssertion("48562591-a97e-4d68-b550-ff089a314bc0","https://AzureManager"));

                var results = new Dictionary<string, string>();
                results.Add("token", authResult.AccessToken);
                results.Add("tenant", authResult.TenantId);

                return results;
            }
        }

        public static string CreateVmAsync()
        {
            var region = Region.GermanyCentral;
            var windowsVmName = "wvM";
            var rgName = "cucu";
            var userName = "tirekicker";
            var password = "12NewPA$$w0rd!";



            //UserLoginInformation login = new UserLoginInformation();
            //login.ClientId = "48562591-a97e-4d68-b550-ff089a314bc0";
            //AzureCredentials credentials = new AzureCredentials(login,"common",AzureEnvironment.AzureGlobalCloud);
            //ServicePrincipalLoginInformation login = new ServicePrincipalLoginInformation();
            Dictionary<string, string> authDataDict = Auth.GetAccessTokenAsync("cucu");

            ServiceClientCredentials serviceClientCred = new TokenCredentials(authDataDict["token"]);

            var restClientBuilder = RestClient.Configure().WithEnvironment(AzureEnvironment.AzureGlobalCloud);
            var restClient = restClientBuilder.WithEnvironment(AzureEnvironment.AzureGlobalCloud).WithCredentials(serviceClientCred).WithDelegatingHandlers().Build();
            var azure = Azure.Authenticate(restClient, authDataDict["tenant"]).WithDefaultSubscription();

            var dataDisk = azure.Disks.Define("dsk-")
                      .WithRegion(region)
                      .WithNewResourceGroup(rgName)
                      .WithData()
                      .WithSizeInGB(50)
                        .Create();

            var dataDiskCreatable = azure.Disks.Define("dsk -")
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)
                        .WithData()
                    .WithSizeInGB(100);

            var windowsVM = azure.VirtualMachines.Define(windowsVmName)
                       .WithRegion(region)
                       .WithNewResourceGroup(rgName)
                       .WithNewPrimaryNetwork("10.0.0.0/28")
                       .WithPrimaryPrivateIpAddressDynamic()
                       .WithoutPrimaryPublicIpAddress()
                       .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012R2Datacenter)
                       .WithAdminUsername(userName)
                       .WithAdminPassword(password)
                       .WithNewDataDisk(10)
                       .WithNewDataDisk(dataDiskCreatable)
                       .WithExistingDataDisk(dataDisk)
                       .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                    .Create();

            windowsVM.Update()
                        .WithTag("who-rocks", "java")
                        .WithTag("where", "on azure")
                        .Apply();

            return "VM CREATED!";
        }

        static void Main(string[] args)
        {
            Program.CreateVmAsync();
            Console.ReadKey();
        }
    }
}
