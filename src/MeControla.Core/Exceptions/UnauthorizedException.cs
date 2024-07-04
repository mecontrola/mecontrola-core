using System;

namespace MeControla.Core.Exceptions
{
    public class UnauthorizedException(Exception innerException)
        : Exception(null, innerException)
    {
        public UnauthorizedException()
            : this(null)
        { }
    }
}