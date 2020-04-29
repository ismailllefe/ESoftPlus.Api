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
    public class TagsController : BaseController
    {
        private readonly ITagsService _tagsService;

        public TagsController(IBusPublisher busPublisher, ITracer tracer,
            ITagsService tagsService) : base(busPublisher, tracer)
        {
            _tagsService = tagsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseTags query)
            => Collection(await _tagsService.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _tagsService.GetAsync(id));

        [HttpPost]
        [AdminAuth]
        public async Task<IActionResult> Post(CreateTag command)
            => await SendAsync(command.BindId(c => c.Id),
                resourceId: command.Id, resource: "tags");

        [HttpPut("{id}")]
        [AdminAuth]
        public async Task<IActionResult> Put(Guid id, UpdateTag command)
            => await SendAsync(command.Bind(c => c.Id, id),
                resourceId: command.Id, resource: "tags");

        [HttpDelete("{id}")]
        [AdminAuth]
        public async Task<IActionResult> Delete(Guid id)
            => await SendAsync(new DeleteTag(id));
    }
}