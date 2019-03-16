using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace MerchTimeline.Domain.Requests.Commands
{
    public class DeleteUsagePeriodCommand : AuthenticatedRequestBase , IRequest
    {
        public long Id { get; set; }
    }
}
