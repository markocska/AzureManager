using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib.Services
{
    public interface IAzureService<K>
    {
        Task<IList<K>> GetResourcesAsync();
    }
}
