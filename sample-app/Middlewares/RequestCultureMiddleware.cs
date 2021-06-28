using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Middlewares
{
    public class RequestCultureMiddleware
    {
        private readonly RequestDelegate _next;

        // Purpose of RequestDelegate is to call next middleware
        public RequestCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Conversion :  Read :  CultureCode :  QueryString => CountryName
            // Read QueryString
            var cultureQuery = context.Request.Query["cultureinfo"];
            // Conversion
            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                var cultureName = new CultureInfo(cultureQuery);
                //de-DE :  Germany
                CultureInfo.CurrentCulture = cultureName; //  Convert :  de-DE = To Set
                CultureInfo.CurrentUICulture = cultureName; // Convert // DateFormat CurrenCy format
                
            }
            // Call Next Middleware
            await _next(context);

        }
    }
}
