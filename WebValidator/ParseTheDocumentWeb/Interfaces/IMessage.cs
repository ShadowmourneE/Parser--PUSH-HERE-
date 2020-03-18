using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParseTheDocumentWeb.Models
{
    public interface IMessage
    {
        int Row { get; set; }
        string Message { get; set; }
        string Line { get; set; }
    }
}
