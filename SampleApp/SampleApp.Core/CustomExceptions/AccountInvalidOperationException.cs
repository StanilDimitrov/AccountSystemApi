using System;

namespace SampleApp.Core.CustomExceptions
{
    public class AccountInvalidOperationException : Exception
    {
        public AccountInvalidOperationException()
        {
        }

        public AccountInvalidOperationException(string message)
            : base(message)
        {
        }

        public AccountInvalidOperationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
