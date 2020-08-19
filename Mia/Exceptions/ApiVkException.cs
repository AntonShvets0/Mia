using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Exceptions
{
    public class ApiVkException : ApiException
    {
        public ApiVkException(string message) : base("Vkontakte", message) { }
    }
}
