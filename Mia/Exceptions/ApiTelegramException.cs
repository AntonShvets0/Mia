using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Exceptions
{
    public class ApiTelegramException : ApiException
    {
        public ApiTelegramException(string message) : base("Telegram", message) { }
    }
}
