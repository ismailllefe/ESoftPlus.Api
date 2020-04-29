using ESoftPlus.Api.Framework;
using ESoftPlus.Api.Messages.Commands.Companies;
using ESoftPlus.Api.Queries;
using ESoftPlus.Api.Services;
using ESoftPlus.Common.Mvc;
using ESoftPlus.Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using System;
using System.Threading.Tasks;

namespace ESoftPlus.Api.Controllers
{
    public class CompaniesController : BaseController
    {
        private readonly ICompaniesService _companiesService;

        public CompaniesController(IBusPublisher busPublisher, ITracer tracer,
            ICompaniesService companiesService) : base(busPublisher, tracer)
        {
            _companiesService = companiesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseCompanies query)
            => Collection(await _companiesService.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _companiesService.GetAsync(id));

        [HttpPost]
        [AdminAuth]
        public async Task<IActionResult> Post(CreateCompany command)
            => await SendAsync(command.BindId(c => c.Id),
                resourceId: command.Id, resource: "companies");

        [HttpPut("{id}")]
        [AdminAuth]
        public async Task<IActionResult> Put(Guid id, UpdateCompany command)
            => await SendAsync(command.Bind(c => c.Id, id),
                resourceId: command.Id, resource: "companies");

        [HttpDelete("{id}")]
        [AdminAuth]
        public async Task<IActionResult> Delete(Guid id)
            => await SendAsync(new DeleteCompany(id));
    }
}