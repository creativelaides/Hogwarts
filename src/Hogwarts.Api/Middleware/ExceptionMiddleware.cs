using System.Net;
using Hogwarts.Application.Core;

namespace Hogwarts.Api.Middleware;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionMiddleware> _logger = logger;
    private readonly IHostEnvironment _env = env;

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorResponse = _env.IsDevelopment()
                ? new AppException(
                    httpContext.Response.StatusCode,
                    ex.Message,
                    ex.StackTrace?.ToString())
                : new AppException(
                    httpContext.Response.StatusCode,
                    "Internal Server Error");

            await httpContext.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}