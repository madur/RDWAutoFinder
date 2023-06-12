
namespace AutoFinder.Application.Exceptions
{
    public class NotFoundException: AutoFinderApplicationException
    {
        public NotFoundException(string name, object key, string title = "")
          : base($"{name} ({key}) is not found", title)
        {
        }

        public static void Throw(string name, object key, string title = "")
        {
            throw new NotFoundException(name, key, title);
        }
    }
}