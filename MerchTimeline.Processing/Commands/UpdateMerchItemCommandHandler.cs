using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchTimeline.Domain.Entities;
using MerchTimeline.Domain.Exceptions;
using MerchTimeline.Domain.Requests;
using MerchTimeline.Domain.Requests.Commands;
using MerchTimeline.Interfaces;

namespace MerchTimeline.Processing.Commands
{
    public class UpdateMerchItemCommandHandler : IRequestHandler<UpdateMerchItemCommand>
    {
        private readonly IServiceBase<MerchItem> _itemsService;
        private readonly IServiceBase<MerchType> _typeService;

        public UpdateMerchItemCommandHandler(
            IServiceBase<MerchItem> itemsService,
            IServiceBase<MerchType> typeService)
        {
            _itemsService = itemsService;
            _typeService = typeService;
        }

        public Task<Unit> Handle(UpdateMerchItemCommand request, CancellationToken cancellationToken)
        {
            var item = _itemsService.CheckOwnership(request, request.MerchItem.Id);

            item.Name = request.MerchItem.Name;
            item.ImageUrl = request.MerchItem.ImageUrl;
            item.ItemTypeId = _typeService.FirstOrDefault(type => type.Kind == request.MerchItem.Kind).Id;

            _itemsService.Update(item);

            return Unit.Task;
        }
    }
}
