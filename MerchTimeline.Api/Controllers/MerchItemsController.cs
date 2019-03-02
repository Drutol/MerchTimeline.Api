using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchTimeline.Domain.Requests;
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
            return Ok(await Mediator.Send(command));
        }
    }
}
