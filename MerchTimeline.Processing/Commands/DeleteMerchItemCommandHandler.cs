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
    public class DeleteMerchItemCommandHandler : IRequestHandler<DeleteMerchItemCommand>
    {
        private IServiceBase<MerchItem> _itemsService;

        public DeleteMerchItemCommandHandler(IServiceBase<MerchItem> itemsService)
        {
            _itemsService = itemsService;
        }

        public Task<Unit> Handle(DeleteMerchItemCommand request, CancellationToken cancellationToken)
        {
            var item = _itemsService.CheckOwnership(request, request.Id);

            _itemsService.Remove(item);

            return Unit.Task;
        }
    }
}
