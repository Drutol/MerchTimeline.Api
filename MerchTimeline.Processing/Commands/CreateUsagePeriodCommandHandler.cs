using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchTimeline.Domain.Entities;
using MerchTimeline.Domain.Exceptions;
using MerchTimeline.Domain.Requests.Commands;
using MerchTimeline.Interfaces;

namespace MerchTimeline.Processing.Commands
{
    public class CreateUsagePeriodCommandHandler : IRequestHandler<CreateUsagePeriodCommand>
    {
        private readonly IServiceBase<MerchItemUsagePeriod> _periodService;
        private readonly IServiceBase<MerchItem> _itemService;
        private readonly IServiceBase<MerchSlot> _slotService;

        public CreateUsagePeriodCommandHandler(
            IServiceBase<MerchItemUsagePeriod> periodService,
            IServiceBase<MerchItem> itemService,
            IServiceBase<MerchSlot> slotService)
        {
            _periodService = periodService;
            _itemService = itemService;
            _slotService = slotService;
        }

        public Task<Unit> Handle(CreateUsagePeriodCommand request, CancellationToken cancellationToken)
        {
            _itemService.CheckOwnership(request, request.MerchItemId);
            _slotService.CheckOwnership(request, request.SlotId);
                     
            _periodService.Add(new MerchItemUsagePeriod
            {
                OwnerId = request.UserId,

                Start = request.Start,
                End = request.End,

                MerchItemId = request.MerchItemId,
                MerchSlotId = request.SlotId,
            });

            return Unit.Task;
        }
    }
}
