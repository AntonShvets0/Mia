using Mia.Interfaces.Api;
using Mia.Interfaces.Bot;
using Mia.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Library.Providers
{
    public class TelegramProvider : IPlatformProvider
    {
        public IUser CreateUser(NewMessage update)
        {
            throw new NotImplementedException();
        }

        public IApiProvider GetApi()
        {
            throw new NotImplementedException();
        }

        public List<NewMessage> GetUpdates()
        {
            throw new NotImplementedException();
        }
    }
}
