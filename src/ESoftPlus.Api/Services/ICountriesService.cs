using ESoftPlus.Api.Models.Country;
using ESoftPlus.Api.Queries;
using ESoftPlus.Common.Types;
using RestEase;
using System;
using System.Threading.Tasks;

namespace ESoftPlus.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ICountriesService
    {
        [AllowAnyStatusCode]
        [Get("countries/{id}")]
        Task<Country> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("countries")]
        Task<PagedResult<Country>> BrowseAsync([Query] BrowseCountries query);
    }
}