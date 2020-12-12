using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipper.MessageLogic.AllMessagesControllers
{
    public abstract class AbstractMessage
    {
        public virtual string GetMessage(IEnumerable<StringBuilder> messageCollection, string name = null)
        {
            Random random = new Random();
            int index = random.Next(0, 4);
            var res = (StringBuilder)messageCollection.ToArray().GetValue(index);
            res.Append(", " + name);
            return res.ToString();

        }
    }
}
