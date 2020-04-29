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
    public class IndustrialProtocolsController : BaseController
    {
        private readonly IIndustrialProtocolsService _industrialProtocolService;

        public IndustrialProtocolsController(IBusPublisher busPublisher, ITracer tracer,
            IIndustrialProtocolsService industrialProtocolService) : base(busPublisher, tracer)
        {
            _industrialProtocolService = industrialProtocolService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseIndustrialProtocol query)
            => Collection(await _industrialProtocolService.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _industrialProtocolService.GetAsync(id));

        [HttpPost]
        [AdminAuth]
        public async Task<IActionResult> Post(CreateIndustrialProtocol command)
            => await SendAsync(command.BindId(c => c.Id),
                resourceId: command.Id, resource: "industrialprotocols");

        [HttpPut("{id}")]
        [AdminAuth]
        public async Task<IActionResult> Put(Guid id, UpdateIndustrialProtocol command)
            => await SendAsync(command.Bind(c => c.Id, id),
                resourceId: command.Id, resource: "industrialprotocols");

        [HttpDelete("{id}")]
        [AdminAuth]
        public async Task<IActionResult> Delete(Guid id)
            => await SendAsync(new DeleteIndustrialProtocol(id));
    }
}