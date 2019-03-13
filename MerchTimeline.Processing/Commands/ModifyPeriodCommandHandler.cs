using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchTimeline.Domain.Entities;
using MerchTimeline.Domain.Models;
using MerchTimeline.Domain.Requests.Commands;
using MerchTimeline.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MerchTimeline.Processing.Commands
{
    public class ModifyPeriodCommandHandler : IRequestHandler<ModifyPeriodCommand, TimelineEntry>
    {
        private readonly IServiceBase<MerchItemUsagePeriod> _periodService;

        public ModifyPeriodCommandHandler(IServiceBase<MerchItemUsagePeriod> periodService)
        {
            _periodService = periodService;
        }

        public Task<TimelineEntry> Handle(ModifyPeriodCommand request, CancellationToken cancellationToken)
        {
            var period = _periodService.CheckOwnership(request, request.Id,
                periods => periods.Include(usagePeriod => usagePeriod.MerchItem));

            period.Start = request.Start;
            period.End = request.End;

            _periodService.Update(period);

            return Task.FromResult(new TimelineEntry
            {
                Id = period.Id,

                End = period.End,
                Start = period.Start,

                Name = period.MerchItem.Name,
                ImageUrl = period.MerchItem.ImageUrl
            });
        }
    }
}
