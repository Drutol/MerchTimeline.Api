using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchTimeline.Domain.Entities;
using MerchTimeline.Domain.Requests;
using MerchTimeline.Interfaces;

namespace MerchTimeline.Processing.Commands
{
    public class CreateMerchItemCommandHandler : IRequestHandler<CreateMerchItemCommand>
    {
        private readonly IServiceBase<MerchItem> _itemsService;
        private readonly IServiceBase<MerchType> _typeService;

        public CreateMerchItemCommandHandler(IServiceBase<MerchItem> itemsService,
            IServiceBase<MerchType> typeService)
        {
            _itemsService = itemsService;
            _typeService = typeService;
        }

        public Task<Unit> Handle(CreateMerchItemCommand request, CancellationToken cancellationToken)
        {
            var item = new MerchItem
            {
                OwnerId = request.UserId,
                ItemTypeId = _typeService.FirstOrDefault(type => type.Kind == request.MerchItem.Kind).Id,
                Name = request.MerchItem.Name,
                ImageUrl = request.MerchItem.ImageUrl
            };

            _itemsService.Add(item);

            return Unit.Task;
        }
    }
}
