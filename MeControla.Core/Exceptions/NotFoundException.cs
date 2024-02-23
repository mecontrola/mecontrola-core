using System;

namespace MeControla.Core.Exceptions
{
    public class NotFoundException(string message)
        : Exception(message)
    {
        public NotFoundException()
            : this(string.Empty)
        { }
    }
}