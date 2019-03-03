using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MerchTimeline.Domain.Models;

namespace MerchTimeline.Domain.Requests.Queries
{
    public class GetTimelineDataQuery : AuthenticatedRequestBase, IRequest<TimelineData>
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
