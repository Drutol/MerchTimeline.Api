using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchTimeline.Domain.Entities;
using MerchTimeline.Domain.Requests.Queries;
using MerchTimeline.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MerchTimeline.Processing.Queries
{
    public class GetMerchItemsQueryHandler : IRequestHandler<GetMerchItemsQuery, List<MerchItem.Dto>>
    {
        private readonly IServiceBase<MerchItem> _itemsService;

        public GetMerchItemsQueryHandler(IServiceBase<MerchItem> itemsService)
        {
            _itemsService = itemsService;
        }

        public async Task<List<MerchItem.Dto>> Handle(GetMerchItemsQuery request, CancellationToken cancellationToken)
        {
            return _itemsService
                .GetAll(item => item.Owner.Id == request.UserId).Include(item => item.ItemType)
                .Select(item => new MerchItem.Dto(item))
                .ToList();
        }
    }
}
