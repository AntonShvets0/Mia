using Mia.Data;
using Mia.Interfaces.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mia
{
    public class Mia
    {
        public HashSet<IPlatformProvider> PlatformProviders = new HashSet<IPlatformProvider>();
        public HashSet<Config> Configs = new HashSet<Config>();

        public static List<ICommand> Commands = new List<ICommand>();
        public static HashSet<IUser> Users = new HashSet<IUser>();

        public Mia()
        {
            Configs.Add(new Config("bot.mia"));
        }

        private static Mia MiaInstance = new Mia();

        public static Mia GetInstance() => MiaInstance;


        public void Run()
        {
            foreach (IPlatformProvider provider in PlatformProviders)
            {
                new Thread(new ParameterizedThreadStart(ThreadWork)).Start(provider);
            }
        }

        private void ThreadWork(object obj)
        {
            if (!(obj is IPlatformProvider)) return;

            new MiaHandler((IPlatformProvider)obj).Start();
        }

        public void GetCommandsUsingReflection()
        {
            Commands.AddRange(new Reflection.Reflection().FindCommands());
        }
    }
}
