using Mia.Interfaces.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Reflection
{
    class Reflection
    {
        public List<ICommand> FindCommands()
        {
            var list = new List<ICommand>();

            foreach (var t in Assembly.GetCallingAssembly().GetTypes().Where(type => type.GetInterfaces().Contains(typeof(ICommand))))
            {
                list.Add((ICommand)Activator.CreateInstance(t));
            }

            return list;
        }
    }
}
