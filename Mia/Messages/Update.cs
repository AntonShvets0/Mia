using Mia.Interfaces.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Messages
{
    public abstract class Update
    {
        public object UserId;

        public object ConversationId;

        public Message Message;

        public IUser GetUser() => Mia.Users.Where(u => u.UserId == UserId).FirstOrDefault();
    }
}
