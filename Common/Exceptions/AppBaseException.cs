using System;

namespace Common.Exceptions
{
    public class AppBaseException : ApplicationException
    {
        public AppBaseException(string message) : base(message)
        { }
    }
}
