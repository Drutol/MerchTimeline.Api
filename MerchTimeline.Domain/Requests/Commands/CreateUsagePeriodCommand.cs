using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace MerchTimeline.Domain.Requests.Commands
{
    public class CreateUsagePeriodCommand : AuthenticatedRequestBase, IRequest
    {
        public long MerchItemId { get; set; }
        public long SlotId { get; set; }

        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
}
