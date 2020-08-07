using Mia.Interfaces.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Response
{
    public class MessageResponse : ICommandResponse
    {
        public string Text { get; set; }

        public MessageResponse(string text)
        {
            Text = text;
        }

        public static implicit operator MessageResponse(string text) => new MessageResponse(text);
    }
}
