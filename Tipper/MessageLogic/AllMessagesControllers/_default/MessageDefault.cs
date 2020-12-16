using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipper.MessageLogic.AllMessagesControllers._default
{
    public class MessageDefault : AbstractMessage, IMessage
    {
        private readonly CustomMessageFactory MessageFactory;
        public string SpecialName { get; set; } = "_default";
        public IEnumerable<StringBuilder> messageCollection { get; set; }

        public MessageDefault(CustomMessageFactory messageFactory)
        {
            messageCollection = new List<StringBuilder>()
            {
                new StringBuilder("знаю ты занят, товарищ, но давай-ка ты посмотришь в окно минутку"),
                new StringBuilder("пришло время... твоим глазам сделать заряд0чку."),
                new StringBuilder("Очерти вглядом символ бесконечности на протяжении минуты и будешь... молодец"),
                new StringBuilder("Слепота тебе не к лицу, так что дай глазам подышать минутку"),
                new StringBuilder("Что бы стать зрячим как Леголасс, нужно рассматривать свои веки на протяжении минуты"),
                new StringBuilder("Отдохнуть пора глазам твоим, я думаю"),
                 new StringBuilder(),
            };
            MessageFactory = messageFactory;
            MessageFactory.Subscribe<MessageDefault>("default");
        }


        public string GetMessage(string name)
        {
            return base.GetMessage(messageCollection, name);
        }
    }


}
