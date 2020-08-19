using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Interfaces.Api
{
    public interface IMessage
    {
        string Text { get; set; }

        List<IAttachment> Attachments { get; set; }
    }
}
