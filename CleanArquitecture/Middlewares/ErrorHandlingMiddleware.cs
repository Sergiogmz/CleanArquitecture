using System.Net;
using System.Text.Json;

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
                // Save response in buffer 
                var originalBodyStream = context.Response.Body;
                using var memoryStream = new MemoryStream();
                context.Response.Body = memoryStream;

                await _next(context); // Next part of pipeline

                // Go back to original stream
                memoryStream.Position = 0;
                await memoryStream.CopyToAsync(originalBodyStream);
                context.Response.Body = originalBodyStream;

                // Just log on responses with code 4xx o 5xx
                if (context.Response.StatusCode >= 400)
                {
                    _logger.LogWarning("HTTP {StatusCode} en {Path}", context.Response.StatusCode, context.Request.Path);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en {Path}", context.Request.Path);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = new { message = ex.Message, error = ex.GetType().Name };
            var jsonResponse = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(jsonResponse);
        }
    }
}