using Mia.Interfaces.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Library.User
{
    public class TelegramUser : IUser
    {
        public object UserId { get; set; }

        public int ChatId { get; set; }

        public string NickName { get; set; }

        public string FirstName { get; set; }
    }
}
