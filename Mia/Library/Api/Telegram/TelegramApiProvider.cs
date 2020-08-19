using Mia.Exceptions;
using Mia.Interfaces.Api;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Library.Api.Telegram
{
    public class TelegramApiProvider : IApiProvider
    {
        public string AccessToken { get; set; }

        public IMessageApi Message { get; set; }

        public TelegramApiProvider(string accessToken)
        {
            AccessToken = accessToken;
            Message = new TelegramMessageApi(this);
        }

        public JObject Call(string method, NameValueCollection args)
        {
            var response = Request.GetJson($"https://api.telegram.org/bot{AccessToken}/{method}", args);

            if ((bool)response["ok"] == false)
            {
                throw new ApiTelegramException($"Code: ${response["error_code"]}, text: ${response["description"]}");
            }

            return (JObject)response["result"];
        }
    }
}
