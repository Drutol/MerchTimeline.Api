using System;
using MediatR;
using MerchTimeline.Domain.Models;

namespace MerchTimeline.Domain.Requests.Commands
{
    public class ModifyPeriodCommand : AuthenticatedRequestBase, IRequest<TimelineEntry>
    {
        public long Id { get; set; }

        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
}
