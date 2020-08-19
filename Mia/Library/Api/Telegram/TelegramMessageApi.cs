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

namespace Mia.Library.Api.Telegram
{
    public class TelegramMessageApi : IMessageApi
    {
        private TelegramApiProvider Provider;

        public TelegramMessageApi(TelegramApiProvider provider)
        {
            Provider = provider;
        }

        public void SendMessage(MessageResponse message, IUser user)
        {
            var text = message.Text;

            if (((TelegramUser)user).ChatId != (int)user.UserId)
            {
                var tgUser = (TelegramUser)user;

                text = $"@{tgUser.NickName},\n" + text;
            }

            Provider.Call("sendMessage", new NameValueCollection() {
                { "chat_id", ((TelegramUser)user).ChatId.ToString() },
                { "text", text }
            });
        }
    }
}
