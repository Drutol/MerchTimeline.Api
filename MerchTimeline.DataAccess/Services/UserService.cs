using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MerchTimeline.Domain.Entities;
using MerchTimeline.Domain.Requests;
using MerchTimeline.Interfaces;

namespace MerchTimeline.DataAccess.Services
{
    public class UserService : ServiceBase<AppUser>, IUserService
    {
        public UserService(TimelineDbContext context) : base(context)
        {

        }

        public AppUser Get(IAuthenticatedRequest request)
        {
            return Context.Users.First(user => user.Id == request.UserId);
        }
    }
}
