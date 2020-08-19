using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(string type, string message) : base($"Api ${type} error: " + message) { }
    }
}
