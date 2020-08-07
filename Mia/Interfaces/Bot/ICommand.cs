using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Interfaces.Bot
{
    public interface ICommand
    {
        string[] Aliases { get; set; }

        ICommandResponse Run(string[] args, IUser user);
    }
}
