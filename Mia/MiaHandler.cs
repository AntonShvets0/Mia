using Mia.Data;
using Mia.Interfaces.Bot;
using Mia.Messages;
using Mia.Response;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mia
{
    class MiaHandler
    {
        IPlatformProvider Provider;
        Mia MiaInstance = Mia.GetInstance();
        Config Config;
        Dictionary<IUser, object> WorkedUsers = new Dictionary<IUser, object>();


        public MiaHandler(IPlatformProvider provider)
        {
            Provider = provider;
            Config = MiaInstance.Configs.Where(c => c.FileName == "bot.mia").First();
        }

        private void HandleUpdate(object obj)
        {
            var update = (NewMessage)obj;

            IUser user;

            if (update.GetUser() == null)
            {
                user = Provider.CreateUser(update);
                Mia.Users.Add(user);
            }
            else
            {
                user = update.GetUser();
            }

            if (!WorkedUsers.ContainsKey(user)) WorkedUsers.Add(user, new object());

            lock (WorkedUsers[user])
            {
                var prefix = GetPrefix();

                if (!update.Message.Text.StartsWith(prefix)) return;

                var command = Mia.Commands.Where(c => c.Aliases.Contains(update.Message.Text.Substring(prefix.Length))).FirstOrDefault();

                if (command == null)
                {
                    Provider.GetApi().Message.SendMessage(GetUnknownCommand(), user);
                }
                else
                {
                    var args = update.Message.Text.Split(' ').ToList();
                    args.RemoveAt(0);

                    var response = command.Run(args.ToArray(), user);

                    if (response is SyntaxErrorResponse)
                    {
                        response = GetSyntaxError();
                    }
                    else if (response is ErrorResponse)
                    {
                        response = GetError(response.Text);
                    }

                    Provider.GetApi().Message.SendMessage(response, user);
                }
            }
        }


        private MessageResponse GetUnknownCommand() => GetError(Config["error.unknown"].ToString());

        private MessageResponse GetSyntaxError() => GetError(Config["error.syntax"].ToString());

        private MessageResponse GetError(string text) => $"{Config["error.prefix"]} ${text}";

        private string GetPrefix()
        {
            var prefix = Config["prefix"];

            if (prefix != null) return prefix.ToString();

            Config["prefix"] = "";
            return "";
        }


        public void Start()
        {
            while (true)
            {
                var updates = Provider.GetUpdates();

                foreach (var update in updates)
                {
                    new Thread(new ParameterizedThreadStart(HandleUpdate)).Start(update);
                }
            }
        }
    }
}
