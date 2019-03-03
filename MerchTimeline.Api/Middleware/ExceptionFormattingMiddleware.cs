using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using MerchTimeline.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MerchTimeline.Api.Middleware
{
    public class ExceptionFormattingMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionFormattingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (exception is ValidationException) code = HttpStatusCode.BadRequest;
            if (exception is UnauthorizedException) code = HttpStatusCode.Unauthorized;

            var result = JsonConvert.SerializeObject(new { error = exception },
                new JsonSerializerSettings { ContractResolver = ExceptionSerializerContractResolver.Instance, ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }


        public class ExceptionSerializerContractResolver : DefaultContractResolver
        {
            public new static readonly ExceptionSerializerContractResolver Instance = new ExceptionSerializerContractResolver();

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty property = base.CreateProperty(member, memberSerialization);

                if (property.DeclaringType == typeof(Exception) &&
                    (property.PropertyName == nameof(Exception.StackTrace) ||
                     property.PropertyName == nameof(Exception.TargetSite)))
                {
                    property.ShouldSerialize = o => false;
                }

                return property;
            }
        }

    }
}
