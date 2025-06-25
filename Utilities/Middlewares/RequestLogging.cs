using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Middlewares
{
    public class RequestLogging
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public RequestLogging(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            logger = loggerFactory.CreateLogger<RequestLogging>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            logger.LogInformation($"Incoming Request: {context.Request.Method} {context.Request.Path}");
            await next(context);
            logger.LogInformation($"Response Status Code: {context.Response.StatusCode}");
        }
    }
}
