using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchTimeline.Domain.Entities;
using MerchTimeline.Domain.Requests.Commands;
using MerchTimeline.Interfaces;

namespace MerchTimeline.Processing.Commands
{
    public class CreateUsagePeriodCommandHandler : IRequestHandler<CreateUsagePeriodCommand>
    {
        private readonly IServiceBase<MerchItemUsagePeriod> _usageService;

        public CreateUsagePeriodCommandHandler(IServiceBase<MerchItemUsagePeriod> usageService)
        {
            _usageService = usageService;
        }

        public Task<Unit> Handle(CreateUsagePeriodCommand request, CancellationToken cancellationToken)
        {
            _usageService.Add(new MerchItemUsagePeriod
            {
                Start = request.Start,
                End = request.End,

                MerchItemId = request.MerchItemId,
                MerchSlotId = request.SlotId,
            });

            return Unit.Task;
        }
    }
}
