using AutoFinder.API.Custom;
using AutoFinder.Application.Exceptions;
using System.Net;

namespace AutoFinder.API.CustomExceptionMiddleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;


        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (AccessViolationException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string message;
            string title = "";

            HttpStatusCode httpStatusCode;
            switch (exception)
            {
                case UnauthorizedAccessException unauthorizedAccessException:
                    httpStatusCode = HttpStatusCode.Unauthorized;
                    message = unauthorizedAccessException.Message;
                    break;

                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    message = badRequestException.Message;
                    title = badRequestException.Title;
                    break;
                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    message = notFoundException.Message;
                    title = notFoundException.Title;
                    break;
                case DataValidationException dataValidationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    message = dataValidationException.Message;
                    title = dataValidationException.Title;
                    break;
                default:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    message = exception.Message;
                    title = "";
                    break;
            }
            _logger.LogError(exception.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;
            await context.Response.WriteAsync(new ErrorDetails(message, title, httpStatusCode).ToString());
        }
    }
}