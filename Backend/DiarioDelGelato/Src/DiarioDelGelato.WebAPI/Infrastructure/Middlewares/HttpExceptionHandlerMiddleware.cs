using Azure;
using DiarioDelGelato.WebAPI.Exceptions;
using System.Net;
using System.Text.Json;

namespace DiarioDelGelato.WebAPI.Infrastructure.Middlewares
{
    //TODO: add Serilog
    public class HttpExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HttpExceptionHandlerMiddleware> _logger;
        private readonly IHostEnvironment _environment;

        public HttpExceptionHandlerMiddleware(RequestDelegate next, ILogger<HttpExceptionHandlerMiddleware> logger, 
            IHostEnvironment environment) 
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{ex.Message} - {ex.InnerException}");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _environment.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    : new ApiException(context.Response.StatusCode, "Internal Server Error");

                var optionsJson = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var jsonResponse = JsonSerializer.Serialize(response, optionsJson);

                await context.Response.WriteAsync(jsonResponse);

            }
        }
    }
}
