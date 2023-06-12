using AutoFinder.Application.Exceptions;
using System;

namespace AutoFinder.Application.Exceptions
{
    [Serializable]
    public class DataValidationException: AutoFinderApplicationException
    {
        public DataValidationException(string message, string title = "")
            : base(message, title)
        {
        }
    }
}