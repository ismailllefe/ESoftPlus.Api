using ESoftPlus.Api.Framework;
using ESoftPlus.Api.Messages.Commands.Cities;
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
    public class CitiesController : BaseController
    {
        private readonly ICitiesService _citiesService;

        public CitiesController(IBusPublisher busPublisher, ITracer tracer,
            ICitiesService citiesService) : base(busPublisher, tracer)
        {
            _citiesService = citiesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseCities query)
            => Collection(await _citiesService.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _citiesService.GetAsync(id));

        [HttpPost]
        [AdminAuth]
        public async Task<IActionResult> Post(CreateCity command)
            => await SendAsync(command.BindId(c => c.Id),
                resourceId: command.Id, resource: "cities");

        [HttpPut("{id}")]
        [AdminAuth]
        public async Task<IActionResult> Put(Guid id, UpdateCity command)
            => await SendAsync(command.Bind(c => c.Id, id),
                resourceId: command.Id, resource: "cities");

        [HttpDelete("{id}")]
        [AdminAuth]
        public async Task<IActionResult> Delete(Guid id)
            => await SendAsync(new DeleteCity(id));
    }
}