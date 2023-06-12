
namespace AutoFinder.Application.Exceptions
{

    public class BadRequestException: AutoFinderApplicationException
    {
        public BadRequestException(string message, string title = "") : base(message, title) { }

        public static void Throw(string message, string title = "")
        {
            throw new BadRequestException(message, title);
        }
    }
}