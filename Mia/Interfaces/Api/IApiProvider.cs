using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Interfaces.Api
{
    public interface IApiProvider
    {
        string AccessToken { get; set; }

        IMessageApi Message { get; set; }
    }
}
