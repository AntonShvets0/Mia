using Mia.Interfaces.Api;
using Mia.Interfaces.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Messages
{
    public abstract class NewMessage
    {
        public object UserId;

        public object ConversationId;

        public IMessage Message;

        public IUser GetUser() => Mia.Users.Where(u => u.UserId == UserId).FirstOrDefault();
    }
}
