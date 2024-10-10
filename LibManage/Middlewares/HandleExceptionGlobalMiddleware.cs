using LibManage.Models;
using System.Net;
using System.Text.Json;

namespace LibManage.Middlewares
{
    public class HandleExceptionGlobalMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<HandleExceptionGlobalMiddleware> _logger;

        public HandleExceptionGlobalMiddleware(RequestDelegate next, ILogger<HandleExceptionGlobalMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context) {

            try
            {
                await _next(context);
            }
            catch ( Exception ex ) {

                _logger.LogError(ex, "Ocorreu um erro");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Erro interno do servidor",
                    Detail = ex.Message
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        
        }
    }
}
