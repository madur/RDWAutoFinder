using AutoFinder.Application.Resource;
using System.Net;

namespace AutoFinder.API.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEY = GenericStrings.ApiKeyCaption;
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKEY, out var extractedApiKey))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync(ErrorMessages.ApiKeyNotProvided);
                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();

            //TODO: Move API Key to Storage(DB)
            var apiKey = appSettings.GetSection("GeneralSettings").GetValue<string>(APIKEY);

            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync(ErrorMessages.UnauthorizedClient);
                return;
            }

            await _next(context);
        }
    }
}
