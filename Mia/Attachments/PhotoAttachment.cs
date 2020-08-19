using Mia.Interfaces.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mia.Attachments
{
    public class PhotoAttachment : IAttachment
    {
        public string Type { get; set; } = "photo";

        public string PhotoUrl { get; set; } = null;

        public byte[] Photo { get; set; } = null;
    }
}
