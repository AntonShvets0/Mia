
using Mia.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Data
{
    public class Config
    {
        private Dictionary<string, object> Configs = new Dictionary<string, object>();
        public IConfigProvider ConfigProvider = new IniProvider();
        public string FileName { get; protected set; }


        public Config(string fileName, IConfigProvider provider = null)
        {
            FileName = fileName;

            if (provider != null)
            {
                ConfigProvider = provider;
            }

            if (File.Exists($"config/${fileName}"))
            {
                Configs = ConfigProvider.Read(File.ReadAllText($"config/{fileName}"));
            }
        }


        public void Save()
        {
            var path = $"config/{FileName}";
            var data = ConfigProvider.Save(Configs);

            File.WriteAllText(path, data);
        }

        public object this[string key]
        {
            get
            {
                if (Configs.ContainsKey(key)) return Configs[key];
                return null;
            }
            set
            {
                if (Configs.ContainsKey(key))
                {
                    Configs[key] = value;
                }
                else
                {
                    Configs.Add(key, value);
                }
            }
        }
    }
}
