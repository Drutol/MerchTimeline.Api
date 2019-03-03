using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchTimeline.Domain.Entities;
using MerchTimeline.Domain.Models;
using MerchTimeline.Domain.Requests.Queries;
using MerchTimeline.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MerchTimeline.Processing.Queries
{
    public class GetTimelineDataQueryHandler : IRequestHandler<GetTimelineDataQuery, TimelineData>
    {
        private readonly IUserService _userService;
        private readonly IServiceBase<MerchItemUsagePeriod> _usageService;

        public GetTimelineDataQueryHandler(IUserService userService, IServiceBase<MerchItemUsagePeriod> usageService)
        {
            _userService = userService;
            _usageService = usageService;
        }

        public async Task<TimelineData> Handle(GetTimelineDataQuery request, CancellationToken cancellationToken)
        {
            var user = _userService.Get(request);

            var periods =_usageService
                .GetAll(period => period.MerchItem.OwnerId == request.UserId && 
                                  period.Start >= request.From && 
                                  period.End <= request.To)
                .Include(period => period.MerchItem)
                .Include(period => period.MerchSlot)
                .ToList();

            var slotGroups = periods.GroupBy(period => period.MerchSlot);

            var output = new TimelineData
            {
                Slots = slotGroups.Select(grouping => new TimelineSlot
                {
                    Name = grouping.Key.Name,
                    Order = 1,
                    TimelineEntries = grouping.Select(period => new TimelineEntry
                    {
                        Name = period.MerchItem.Name,
                        ImageUrl = period.MerchItem.ImageUrl,
                        Start = period.Start,
                        End = period.End,
                    }).ToList()
                }).ToList()
            };

            return output;
        }
    }
}
