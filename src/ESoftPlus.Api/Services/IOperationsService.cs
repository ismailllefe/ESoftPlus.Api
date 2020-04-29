using ESoftPlus.Api.Models.Operations;
using RestEase;
using System;
using System.Threading.Tasks;

namespace ESoftPlus.Api.Services
{
    public interface IOperationsService
    {
        [AllowAnyStatusCode]
        [Get("operations/{id}")]
        Task<Operation> GetAsync([Path] Guid id);
    }
}