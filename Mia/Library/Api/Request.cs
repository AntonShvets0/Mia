using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Library.Api
{
    public class Request
    {
        public static string Get(string url, NameValueCollection args) => Encoding.UTF8.GetString(new WebClient().UploadValues(url, "POST", args));

        public static JObject GetJson(string url, NameValueCollection args) => JObject.Parse(Get(url, args));
    }
}
