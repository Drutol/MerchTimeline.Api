using System;
using System.Collections.Generic;
using System.Text;
using MerchTimeline.Interfaces;

namespace MerchTimeline.Domain.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message) : base(message)
        {

        }

        public static UnauthorizedException From(IAuthenticatedRequest authenticatedRequest)
        {
            return new UnauthorizedException(
                $"Failed to authorize {authenticatedRequest.GetType().Name} with given {nameof(authenticatedRequest.Token)}");
        }
    }
}
