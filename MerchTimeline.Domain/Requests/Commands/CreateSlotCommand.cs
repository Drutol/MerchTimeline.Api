using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MerchTimeline.Domain.Enums;

namespace MerchTimeline.Domain.Requests.Commands
{
    public class CreateSlotCommand : AuthenticatedRequestBase, IRequest
    {
        public string Name { get; set; }
        public MerchKind Kind { get; set; }
    }
}
