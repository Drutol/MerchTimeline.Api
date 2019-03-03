using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace MerchTimeline.Domain.Requests
{
    public abstract class AuthenticatedRequestBase : IAuthenticatedRequest
    {
        public string Token { get; set; }
        public long UserId { get; set; }
    }
}
