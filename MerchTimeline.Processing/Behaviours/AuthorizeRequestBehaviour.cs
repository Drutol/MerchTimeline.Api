using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;
using MerchTimeline.Domain.Entities;
using MerchTimeline.Domain.Exceptions;
using MerchTimeline.Domain.Requests;
using MerchTimeline.Interfaces;

namespace MerchTimeline.Processing.Behaviours
{
    public class AuthorizeRequestBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : IAuthenticatedRequest
    {
        private readonly IServiceBase<AppUser> _usersService;

        public AuthorizeRequestBehaviour(IServiceBase<AppUser> usersService)
        {
            _usersService = usersService;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            if (request is IAuthenticatedRequest authRequest)
            {
                var user = _usersService.FirstOrDefault(appUser => appUser.AuthToken == authRequest.Token);

                if(user == null)
                    throw UnauthorizedException.From(authRequest);

                authRequest.UserId = user.Id;
            }

            return Task.CompletedTask;
        }
    }
}
