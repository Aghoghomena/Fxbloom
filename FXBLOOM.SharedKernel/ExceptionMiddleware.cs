using FXBLOOM.SharedKernel.Logging.NlogFile;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FXBLOOM.SharedKernel
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILog _log;
        public ExceptionMiddleware(RequestDelegate next, ILog log)
        {
            _log = log;
            _next = next;
        }

        //try catch thats supposed to run at every http request
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _log.Error($"Oops!!!  => Context => {httpContext?.Request?.Path} => {ex?.Message} | {ex?.InnerException?.InnerException} | {ex?.InnerException?.InnerException?.StackTrace}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync("We are currently experiencing some issues. Please try again in 1 hour.");
        }
    }
}
