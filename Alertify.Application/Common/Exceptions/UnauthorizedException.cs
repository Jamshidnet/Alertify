﻿namespace Alertify.Application.Common.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException()
        { }
        public UnauthorizedException(string message)
            : base(message)
        { }

        public UnauthorizedException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public UnauthorizedException(string message, object key)
            : base($"ApplicationUser :{message} with {key} is not authorized")
        { }
    }
}
