﻿using ESoftPlus.Api.Services;
using ESoftPlus.Common.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using System;
using System.Threading.Tasks;

namespace ESoftPlus.Api.Controllers
{
    [AllowAnonymous]
    public class OperationsController : BaseController
    {
        private readonly IOperationsService _operationsService;

        public OperationsController(IBusPublisher busPublisher, ITracer tracer,
            IOperationsService operationsService) : base(busPublisher, tracer)
        {
            _operationsService = operationsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _operationsService.GetAsync(id));
    }
}