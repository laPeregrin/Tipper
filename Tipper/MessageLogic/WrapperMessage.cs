using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipper.MessageLogic
{
    public class WrapperMessage
    {
        public Type _TypeMessage { get; set; }

        public WrapperMessage(Type _typeMessage)
        {
            _TypeMessage = _typeMessage;
        }
    }
}
