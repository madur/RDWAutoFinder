using System;

namespace AutoFinder.Application.Exceptions
{
    public abstract class AutoFinderApplicationException : ApplicationException
    {

        public AutoFinderApplicationException(string message, string title = "") : base(message)
        {
            Title = title;
        }
        public string Title { get; }
    }
}