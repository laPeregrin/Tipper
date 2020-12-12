using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipper.MessageLogic.AllMessagesControllers._default;
using System.Runtime.Serialization.Formatters;

namespace Tipper.MessageLogic
{
    public class CustomMessageFactory
    {
        private ConcurrentDictionary<WrapperMessage, string> _MessageSubscribers;

        public CustomMessageFactory()
        {
            _MessageSubscribers = new ConcurrentDictionary<WrapperMessage, string>();
        }

        public IMessage GetMessageByName(string name)
        {
            try
            {
                if (_MessageSubscribers == null)
                    throw new Exception("Collection of messageEnginers is empty");
                var res = _MessageSubscribers
                     .Where(s => s.Value.Contains(name))
                     .Select(s => s.Key._TypeMessage);
                Type type = res.FirstOrDefault();
                var message = (IMessage)Activator.CreateInstance(type, this);
                return message;
            }
            catch(Exception e)
            {
                var es = e.Message;
                return new MessageDefault(this);
            }
        }

        public void Subscribe<T>(string name) where T : IMessage
        {
            var messageEngine = new WrapperMessage(typeof(T));
            _MessageSubscribers.TryAdd(messageEngine, name);
        }
    }
}
