using System.Net;
using System.Text.Json;

namespace AutoFinder.API.Custom
{
    public class ErrorDetails
    {
        public HttpStatusCode StatusCode { get; }
        public string Message { get; }
        public string Title { get; }

        public ErrorDetails(string message, string title, HttpStatusCode statusCode)
        {
            Message = message;
            Title = title;
            StatusCode = statusCode;
        }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
