﻿using Mia.Interfaces.Bot;
using Mia.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Interfaces.Api
{
    public interface IMessageApi
    {
        void SendMessage(ICommandResponse message, IUser user);
    }
}