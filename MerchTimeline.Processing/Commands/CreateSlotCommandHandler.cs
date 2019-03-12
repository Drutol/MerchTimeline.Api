using System;
using System.Collections.Generic;
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
    public class CreateSlotCommandHandler : IRequestHandler<CreateSlotCommand>
    {
        private readonly IServiceBase<MerchSlot> _slotService;

        public CreateSlotCommandHandler(IServiceBase<MerchSlot> slotService)
        {
            _slotService = slotService;
        }

        public Task<Unit> Handle(CreateSlotCommand request, CancellationToken cancellationToken)
        {
            if (_slotService.Count(i => i.OwnerId == request.UserId) > 10)
            {
                throw new RequestException("No more than 10 slots allowed.");
            }

            _slotService.Add(new MerchSlot
            {
                Name = request.Name,
                OwnerId = request.UserId,
            });

            return Unit.Task;
        }
    }
}
