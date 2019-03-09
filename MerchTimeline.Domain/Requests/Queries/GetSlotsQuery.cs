using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MerchTimeline.Domain.Entities;

namespace MerchTimeline.Domain.Requests.Queries
{
    public class GetSlotsQuery : AuthenticatedRequestBase, IRequest<List<MerchSlot.Dto>>
    {

    }
}
