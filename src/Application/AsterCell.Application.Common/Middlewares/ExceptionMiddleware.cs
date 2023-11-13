using AsterCell.Application.Common.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace AsterCell.Application.Common.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Exception _ex = ex;
                if (ex.InnerException != null)
                    _ex = ex.InnerException;
                await WriteResponse(context, new NoContent(), new List<string> { _ex.Message }, StatusCodes.Status500InternalServerError);
            }
        }

        private async Task WriteResponse(HttpContext context, object data = null, List<string> message = null, int statusCode = 500)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = statusCode;

            var baseResponse = ApiResponse.Fail(data, message, statusCode);
            var json = JsonSerializer.Serialize(baseResponse);

            await response.WriteAsync(json);
        }
    }
}
