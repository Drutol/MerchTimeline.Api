using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MerchTimeline.Domain.Entities;
using MerchTimeline.Interfaces;

namespace MerchTimeline.Domain.Requests.Queries
{
    public class GetMerchItemsQuery : IRequest<List<MerchItem.Dto>> , IAuthenticatedRequest
    {
        public string Token { get; set; }
        public long UserId { get; set; }
    }
}
