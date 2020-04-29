using ESoftPlus.Api.Framework;
using ESoftPlus.Api.Messages.Commands.Cities;
using ESoftPlus.Api.Messages.Commands.Devices;
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
    public class DevicesController : BaseController
    {
        private readonly IDevicesService _devicesService;

        public DevicesController(IBusPublisher busPublisher, ITracer tracer,
            IDevicesService devicesService) : base(busPublisher, tracer)
        {
            _devicesService = devicesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseDevices query)
            => Collection(await _devicesService.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _devicesService.GetAsync(id));

        [HttpPost]
        [AdminAuth]
        public async Task<IActionResult> Post(CreateDevice command)
            => await SendAsync(command.BindId(c => c.Id),
                resourceId: command.Id, resource: "devices");

        [HttpPut("{id}")]
        [AdminAuth]
        public async Task<IActionResult> Put(Guid id, UpdateDevice command)
            => await SendAsync(command.Bind(c => c.Id, id),
                resourceId: command.Id, resource: "devices");

        [HttpDelete("{id}")]
        [AdminAuth]
        public async Task<IActionResult> Delete(Guid id)
            => await SendAsync(new DeleteDevice(id));
    }
}