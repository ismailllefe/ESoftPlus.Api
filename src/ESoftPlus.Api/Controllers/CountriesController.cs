using ESoftPlus.Api.Framework;
using ESoftPlus.Api.Messages.Commands.Countries;
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
    public class CountriesController : BaseController
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(IBusPublisher busPublisher, ITracer tracer,
            ICountriesService countriesService) : base(busPublisher, tracer)
        {
            _countriesService = countriesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseCountries query)
            => Collection(await _countriesService.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _countriesService.GetAsync(id));

        [HttpPost]
        [AdminAuth]
        public async Task<IActionResult> Post(CreateCountry command)
            => await SendAsync(command.BindId(c => c.Id),
                resourceId: command.Id, resource: "countries");

        [HttpPut("{id}")]
        [AdminAuth]
        public async Task<IActionResult> Put(Guid id, UpdateCountry command)
            => await SendAsync(command.Bind(c => c.Id, id),
                resourceId: command.Id, resource: "countries");

        [HttpDelete("{id}")]
        [AdminAuth]
        public async Task<IActionResult> Delete(Guid id)
            => await SendAsync(new DeleteCountry(id));
    }
}