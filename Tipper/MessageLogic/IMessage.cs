using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipper.MessageLogic
{
    public interface IMessage
    {

        IEnumerable<StringBuilder> messageCollection { get; set; }

        string SpecialName { get; set; }
        string GetMessage(string name);
    }
}
