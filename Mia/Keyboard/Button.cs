using Mia.Interfaces.Bot;
using Mia.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Keyboard
{
    public class Button
    {
        public ButtonColor Color { get; set; }

        public string Text { get; set; }

        public ICommand OnClickCommand { get; set; }

        public delegate MessageResponse OnClickEvent(IUser user);
    }
}
