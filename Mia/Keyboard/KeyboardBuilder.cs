using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Keyboard
{
    public abstract class KeyboardBuilder
    {
        public int MaxInRow = 4;
        public int MaxLines = 12;

        private List<List<Button>> Buttons = new List<List<Button>>();

        public void AddButton(Button button)
        {
            var last = Buttons.LastOrDefault();

            if (last == null || last.Count > MaxInRow)
            {
                Buttons.Add(new List<Button>() { button });
            }
            else
            {
                last.Add(button);
            }
        }
        
        public void AddLine()
        {
            Buttons.Add(new List<Button>());
        }

        public abstract JObject Build();
    }
}
