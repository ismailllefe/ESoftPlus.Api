using ESoftPlus.Api.Models.City;
using ESoftPlus.Api.Queries;
using ESoftPlus.Common.Types;
using RestEase;
using System;
using System.Threading.Tasks;

namespace ESoftPlus.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ICitiesService
    {
        [AllowAnyStatusCode]
        [Get("cities/{id}")]
        Task<City> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("cities")]
        Task<PagedResult<City>> BrowseAsync([Query] BrowseCities query);
    }
}