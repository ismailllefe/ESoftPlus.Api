using ESoftPlus.Api.Models.IndustrialProtocol;
using ESoftPlus.Api.Queries;
using ESoftPlus.Common.Types;
using RestEase;
using System;
using System.Threading.Tasks;

namespace ESoftPlus.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IIndustrialProtocolsService
    {
        [AllowAnyStatusCode]
        [Get("industrialprotocols/{id}")]
        Task<IndustrialProtocol> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("industrialprotocols")]
        Task<PagedResult<IndustrialProtocol>> BrowseAsync([Query] BrowseIndustrialProtocol query);
    }
}