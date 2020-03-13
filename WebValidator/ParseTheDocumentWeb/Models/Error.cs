using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParseTheDocumentWeb.Models
{
    public class Error : IMessage
    {
        public int Row { get; set; }
        public string Message { get; set; }
        public string Line { get; set; }
    }
}
