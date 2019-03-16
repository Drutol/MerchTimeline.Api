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
    [Route("api/timeline")]
    public class TimelineController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTimelineData([FromQuery] DateTime? from = null, [FromQuery] DateTime? to = null)
        {
            return Ok(await Mediator.Send(new GetTimelineDataQuery
            {
                From = from ?? DateTime.MinValue,
                To = to ?? DateTime.MaxValue,
            }.Authenticate(HttpContext)));
        }

        [HttpPost]
        public async Task<IActionResult> AddPeriod(CreateUsagePeriodCommand command)
        {
            return Ok(await Mediator.Send(command.Authenticate(HttpContext)));
        }

        [HttpPost("{id}/modify")]
        public async Task<IActionResult> ModifyPeriod(long id, ModifyPeriodCommand command)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command.Authenticate(HttpContext)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeriod(long id)
        {
            return Ok(await Mediator.Send(new DeleteUsagePeriodCommand
            {
                Id = id
            }.Authenticate(HttpContext)));
        }


    }
}
