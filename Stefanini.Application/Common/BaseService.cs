using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Application.Common
{
    public abstract class BaseService
    {
        public static Boolean ValidatesToUpdate(object first, object second)
        {
            return object.Equals(first, second);
        }
    }
}
