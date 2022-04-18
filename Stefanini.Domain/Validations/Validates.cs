using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stefanini.Domain.Exceptions;

namespace Stefanini.Domain.Validations
{
    public static class Validates
    {
        public static void StringValidations(string model, string message)
        {
            if (string.IsNullOrEmpty(model))
                throw new DomainException(message);
        }

        public static void GreaterThanZero(int model, string message)
        {
            if (model <= 0)
                throw new DomainException(message);
        }
          

    }
}
