using Microsoft.AspNetCore.Builder;
using sample_app.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Extensions
{
    public static class RequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder builder)
        {
            // Call Middleware
           return builder.UseMiddleware<RequestCultureMiddleware>();
        }
    }
}
