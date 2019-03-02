using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MerchTimeline.Domain.Entities;
using MerchTimeline.Interfaces;

namespace MerchTimeline.Domain.Requests
{
    public class CreateMerchItemCommand : IRequest, IAuthenticatedRequest
    {
        public string Token { get; set; }
        public long UserId { get; set; }

        public MerchItem.Dto MerchItem { get; set; }
    }
}
