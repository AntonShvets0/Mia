using Mia.Exceptions;
using Mia.Interfaces.Api;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Library.Api.Vk
{
    public class VkApiProvider : IApiProvider
    {
        public string AccessToken { get; set; }

        public IMessageApi Message { get; set; }

        public string Version { get; set; }

        public VkApiProvider(string accessToken, string version)
        {
            AccessToken = accessToken;
            Version = version;
            Message = new VkMessageApi(this);
        }

        public JObject Call(string group, string method, NameValueCollection args)
        {
            args.Add("access_token", AccessToken);
            args.Add("v", Version);

            var response = Request.GetJson($"https://api.vk.com/${group}.${method}", args);

            if (response.ContainsKey("error"))
            {
                throw new ApiVkException($"Code: ${response["error"]["error_code"]}, text: ${response["error"]["error_msg"]}");
            }

            return (JObject)response["response"];
        }
    }
}
