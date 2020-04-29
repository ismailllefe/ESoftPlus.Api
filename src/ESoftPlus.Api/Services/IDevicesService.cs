using ESoftPlus.Api.Models.Device;
using ESoftPlus.Api.Models.Field;
using ESoftPlus.Api.Queries;
using ESoftPlus.Common.Types;
using RestEase;
using System;
using System.Threading.Tasks;

namespace ESoftPlus.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IDevicesService
    {
        [AllowAnyStatusCode]
        [Get("devices/{id}")]
        Task<Device> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("devices")]
        Task<PagedResult<Device>> BrowseAsync([Query] BrowseDevices query);
    }
}