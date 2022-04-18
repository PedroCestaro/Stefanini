using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Domain.Exceptions
{
    public class DomainException : ArgumentException
    {
        public DomainException() { }

        public DomainException( string message) : base(message) { }

        public DomainException(string message, Exception innerException) : base(message, innerException) { }
    }
}
