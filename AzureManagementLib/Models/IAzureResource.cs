using Microsoft.Azure.Management.Resource.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib.Models
{
    public interface IAzureResource
    {
        string Name { get;  }

        string ResourceGroupName { get;  }

        string Type { get;  }

        string Location { get;  }
    }
}
