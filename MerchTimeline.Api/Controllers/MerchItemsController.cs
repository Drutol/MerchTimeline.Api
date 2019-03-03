﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchTimeline.Api.Utils;
using MerchTimeline.Domain.Requests;
using MerchTimeline.Domain.Requests.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MerchTimeline.Api.Controllers
{
    [ApiController]
    [Route("api/merchItems")]
    public class MerchItemsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateMerchItemCommand command)
        {
            return Ok(await Mediator.Send(command.Authenticate(HttpContext)));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return Ok(await Mediator.Send(new GetMerchItemsQuery().Authenticate(HttpContext)));
        }
    }
}
