using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchTimeline.Api.Utils;
using MerchTimeline.Domain.Requests.Commands;
using MerchTimeline.Domain.Requests.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MerchTimeline.Api.Controllers
{
    [ApiController]
    [Route("api/slots")]
    public class SlotsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSlots()
        {
            return Ok(await Mediator.Send(new GetSlotsQuery().Authenticate(HttpContext)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlot(CreateSlotCommand command)
        {
            return Ok(await Mediator.Send(command.Authenticate(HttpContext)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlot(long id)
        {
            return Ok(await Mediator.Send(new DeleteSlotCommand
            {
                Id = id
            }.Authenticate(HttpContext)));
        }
    }
}
