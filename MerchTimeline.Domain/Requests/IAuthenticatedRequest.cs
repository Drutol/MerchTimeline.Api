using System;
using System.Collections.Generic;
using System.Text;
using MerchTimeline.Domain.Entities;

namespace MerchTimeline.Interfaces
{
    public interface IAuthenticatedRequest
    {
        string Token { get; set; }
        long UserId { get; set; }
    }
}
