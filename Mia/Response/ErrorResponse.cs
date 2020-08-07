using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Response
{
    public class ErrorResponse : MessageResponse
    {
        public ErrorResponse(string text) : base(text)
        {

        }
    }
}
