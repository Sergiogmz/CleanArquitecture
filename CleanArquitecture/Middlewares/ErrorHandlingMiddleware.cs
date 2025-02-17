using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Web.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

                if (context.Response.StatusCode >= 400)
                {
                    _logger.LogWarning("HTTP {StatusCode} en {Path}", context.Response.StatusCode, context.Request.Path);
                }
            }
            catch (BadHttpRequestException ex)
            {
                _logger.LogWarning("Solicitud incorrecta en {Path}: {Message}", context.Request.Path, ex.Message);
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en {Path}", context.Request.Path);
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, Exception ex)
        {
            var response = new
            {
                message = ex.Message,
                error = ex.GetType().Name,
                statusCode = (int)statusCode
            };

            var jsonResponse = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(jsonResponse);
        }
    }
}