using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Interfaces
{
    public interface IConfigProvider
    {
        string Save(Dictionary<string, object> config);

        Dictionary<string, object> Read(string content);
    }
}
