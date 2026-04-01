using FluentValidation;
using ECommerceSimplesBackend.Application.Exceptions;
using System.Net;
using ECommerceSimplesBackend.API.Controllers;

namespace ECommerceSimplesBackend.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning("Validation error: {Message}", ex.Message);
                await HandleValidationExceptionAsync(context, ex);
            }
            catch (ApiException ex)
            {
                _logger.LogWarning(ex.Message);
                await HandleExceptionAsync(context, ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred: {Message}", ex.Message);
                Console.WriteLine($"[ERROR] {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private static async Task HandleValidationExceptionAsync(HttpContext context, ValidationException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var errors = ex.Errors
                .Select(e => e.ErrorMessage)
                .ToList();

            var response = new ApiResponse<object>
            {
                Status = false,
                Message = "Erro de validação.",
                Data = errors
            };

            await context.Response.WriteAsJsonAsync(response);
        }

        private static async Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new ApiResponse<object>
            {
                Status = false,
                Message = message,
                Data = null
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}