using ESoftPlus.Api.Models.Field;
using ESoftPlus.Api.Queries;
using ESoftPlus.Common.Types;
using RestEase;
using System;
using System.Threading.Tasks;

namespace ESoftPlus.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IFieldsService
    {
        [AllowAnyStatusCode]
        [Get("fields/{id}")]
        Task<Field> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("fields")]
        Task<PagedResult<Field>> BrowseAsync([Query] BrowseFields query);
    }
}