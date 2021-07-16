using System;
using System.Collections.Generic;

namespace Users.Core.Exceptions
{
    public class DomainException : Exception
    {
        internal List<string> _errors { get; set; }

        public IReadOnlyCollection<string> Errors
        {
            get
            {
                return _errors;
            }
        }

        public DomainException()
        {

        }
        public DomainException(string message, List<string> errors) : base(message)
        {
            _errors = errors;
        }

        public DomainException(string message) : base(message)
        {

        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}