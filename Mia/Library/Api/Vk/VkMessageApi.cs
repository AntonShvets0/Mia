using Mia.Interfaces.Api;
using Mia.Interfaces.Bot;
using Mia.Library.User;
using Mia.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Library.Api.Vk
{
    public class VkMessageApi : IMessageApi
    {
        private VkApiProvider Provider;

        public VkMessageApi(VkApiProvider provider)
        {
            Provider = provider;
        }

        public void SendMessage(MessageResponse message, IUser user)
        {
            var text = message.Text;

            if (((VkUser)user).PeerId != (int)user.UserId)
            {
                var vkUser = (VkUser)user;

                text = $"@id{user.UserId}({vkUser.FirstName} {vkUser.LastName}),\n" + text;
            }

            Provider.Call("messages", "send", new NameValueCollection() {
                { "peer_id", ((VkUser)user).PeerId.ToString() },
                { "random_id", new Random().Next(0, 1000).ToString() },
                { "message", text },
                { "disable_mentions", "1" }
            });
        }
    }
}
