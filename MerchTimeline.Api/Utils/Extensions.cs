using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MerchTimeline.Domain.Requests;
using MerchTimeline.Interfaces;
using Microsoft.AspNetCore.Http;

namespace MerchTimeline.Api.Utils
{
    public static class Extensions
    {
        public static T Authenticate<T>(this T request, HttpContext context) where  T : IBaseRequest
        {
            if(request is IAuthenticatedRequest authReqest)
                authReqest.Token = context.Request.Headers["Authorization"];
            return request;
        }
    }
}
