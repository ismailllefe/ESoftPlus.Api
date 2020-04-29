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
    public class FieldsController : BaseController
    {
        private readonly IFieldsService _fieldsService;

        public FieldsController(IBusPublisher busPublisher, ITracer tracer,
            IFieldsService fieldsService) : base(busPublisher, tracer)
        {
            _fieldsService = fieldsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseFields query)
            => Collection(await _fieldsService.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _fieldsService.GetAsync(id));

        [HttpPost]
        [AdminAuth]
        public async Task<IActionResult> Post(CreateField command)
            => await SendAsync(command.BindId(c => c.Id),
                resourceId: command.Id, resource: "fields");

        [HttpPut("{id}")]
        [AdminAuth]
        public async Task<IActionResult> Put(Guid id, UpdateField command)
            => await SendAsync(command.Bind(c => c.Id, id),
                resourceId: command.Id, resource: "fields");

        [HttpDelete("{id}")]
        [AdminAuth]
        public async Task<IActionResult> Delete(Guid id)
            => await SendAsync(new DeleteCity(id));
    }
}