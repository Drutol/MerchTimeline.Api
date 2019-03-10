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
    public class DeleteSlotCommandHandler : IRequestHandler<DeleteSlotCommand>
    {
        private readonly IServiceBase<MerchSlot> _slotsService;

        public DeleteSlotCommandHandler(IServiceBase<MerchSlot> slotsService)
        {
            _slotsService = slotsService;
        }

        public async Task<Unit> Handle(DeleteSlotCommand request, CancellationToken cancellationToken)
        {
            var slot = _slotsService.FirstOrDefault(s => s.OwnerId == request.UserId && s.Id == request.Id);
            if (slot == null)
                return Unit.Value;

            _slotsService.Remove(slot);

            return Unit.Value;
        }
    }
}
