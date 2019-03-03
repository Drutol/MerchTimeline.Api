using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchTimeline.Api.Utils;
using MerchTimeline.Domain.Requests.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MerchTimeline.Api.Controllers
{
    [ApiController]
    [Route("api/slots")]
    public class SlotsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateSlot(CreateSlotCommand command)
        {
            return Ok(await Mediator.Send(command.Authenticate(HttpContext)));
        }
    }
}
