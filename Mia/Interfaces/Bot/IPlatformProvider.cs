﻿using Mia.Interfaces.Api;
using Mia.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Interfaces.Bot
{
    public interface IPlatformProvider
    {
        List<NewMessage> GetUpdates();

        IUser CreateUser(NewMessage update);

        IApiProvider GetApi();
    }
}
