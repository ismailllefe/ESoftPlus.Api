using ESoftPlus.Api.Models.Tag;
using ESoftPlus.Api.Queries;
using ESoftPlus.Common.Types;
using RestEase;
using System;
using System.Threading.Tasks;

namespace ESoftPlus.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ITagsService
    {
        [AllowAnyStatusCode]
        [Get("tags/{id}")]
        Task<Tag> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("tags")]
        Task<PagedResult<Tag>> BrowseAsync([Query] BrowseTags query);
    }
}