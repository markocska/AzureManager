using Microsoft.Azure.Management.Resource.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib.Models
{
    public abstract class AzureResource<T> : IAzureResource
        where T : IResource, IHasResourceGroup
    {
        T resource;
        public string Name { get { return resource.Name;  }  }

        public string ResourceGroupName { get { return resource.ResourceGroupName; }  }

        public string Type { get { return resource.Type; }  }

        public string Location { get { return resource.RegionName; }  }

        public AzureResource(T resource )
        {
            this.resource = resource;
        }
    }
}
