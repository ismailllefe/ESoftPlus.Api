using System;
using System.Threading.Tasks;
using RestEase;
using ESoftPlus.Api.Models.Operations;

namespace ESoftPlus.Api.Services
{
    public interface IOperationsService
    {
        [AllowAnyStatusCode]
        [Get("operations/{id}")]
        Task<Operation> GetAsync([Path] Guid id);          
    }
}