using ESoftPlus.Api.Models.Company;
using ESoftPlus.Api.Queries;
using ESoftPlus.Common.Types;
using RestEase;
using System;
using System.Threading.Tasks;

namespace ESoftPlus.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ICompaniesService
    {
        [AllowAnyStatusCode]
        [Get("companies/{id}")]
        Task<Company> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("companies")]
        Task<PagedResult<Company>> BrowseAsync([Query] BrowseCompanies query);
    }
}