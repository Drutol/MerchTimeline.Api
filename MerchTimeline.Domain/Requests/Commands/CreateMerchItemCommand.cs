using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MerchTimeline.Domain.Entities;

namespace MerchTimeline.Domain.Requests
{
    public class CreateMerchItemCommand : AuthenticatedRequestBase, IRequest
    {    
        public MerchItem.Dto MerchItem { get; set; }
    }
}
