using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SampleApp.Core.CustomExceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SampleApp.Core.Utilities
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (AccountInvalidOperationException ex)
            {
                _logger.LogError(ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (OperationCanceledException)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync("Your submission was canceled.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("Something went horribly wrong!");
            }
        }
    }
}
