using Mia.Data;
using Mia.Interfaces.Api;
using Mia.Interfaces.Bot;
using Mia.Library.Api.Vk;
using Mia.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Library.Providers
{
    public class VkProvider : IPlatformProvider
    {
        private Config Config = Mia.GetInstance().Configs.Where(c => c.FileName == "vk.ini").First();

        private VkApiProvider Api;

        public VkProvider()
        {
            Api = new VkApiProvider(Config["access_token"].ToString(), Config["version"].ToString());
        }

        public IUser CreateUser(NewMessage update)
        {
            throw new NotImplementedException();
        }

        public IApiProvider GetApi() => Api;

        public List<NewMessage> GetUpdates()
        {
            throw new NotImplementedException();
        }
    }
}
