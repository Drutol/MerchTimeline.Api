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
    public class GetSlotsQueryHandler : IRequestHandler<GetSlotsQuery, List<MerchSlot.Dto>>
    {
        private readonly IServiceBase<AppUser> _userService;

        public GetSlotsQueryHandler(IServiceBase<AppUser> userService)
        {
            _userService = userService;
        }

        public async Task<List<MerchSlot.Dto>> Handle(GetSlotsQuery request, CancellationToken cancellationToken)
        {
            return _userService.GetAll(user => user.Id == request.UserId).Include(user => user.MerchSlots)
                .SelectMany(user => user.MerchSlots)
                .Select(slot => new MerchSlot.Dto(slot))
                .ToList();
        }
    }
}
