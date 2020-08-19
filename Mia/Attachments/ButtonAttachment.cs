using Mia.Interfaces.Api;
using Mia.Keyboard;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Attachments
{
    public class ButtonAttachment : IAttachment
    {
        public string Type { get; set; } = "button";

        public KeyboardBuilder Buttons { get; set; }    
    }
}
