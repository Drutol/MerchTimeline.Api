using System;
using System.Collections.Generic;
using System.Text;
using MerchTimeline.Domain.Entities;
using MerchTimeline.Domain.Requests;

namespace MerchTimeline.Interfaces
{
    public interface IUserService : IServiceBase<AppUser>
    {
        AppUser Get(IAuthenticatedRequest request);
    }
}
