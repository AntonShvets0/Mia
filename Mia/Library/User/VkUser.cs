using Mia.Interfaces.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Library.User
{
    class VkUser : IUser
    {
        public object UserId { get; set; }

        public int PeerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
