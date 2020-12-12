using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipper.MessageLogic.AllMessagesControllers.Customs
{
    public class MaximMessage : AbstractMessage, IMessage
    {
        public IEnumerable<StringBuilder> messageCollection { get; set; }
        private readonly CustomMessageFactory _messageFactory;
        public MaximMessage(CustomMessageFactory messageFactory)
        {
            messageCollection = new List<StringBuilder>()
            {
            new StringBuilder("Не важно, код или игра, дай глазам подышать"),
            new StringBuilder("Отдохни минутку").Append(", " + SpecialName),
            new StringBuilder("Ни слова по-русски"),
            new StringBuilder("Ты приближаешься ко мне").Append(", " + SpecialName + ",").Append("? Расслабь глаза"),
            new StringBuilder("Проморгайся на протяжении минуты, получишь + 10к интелекту"),
            new StringBuilder("Потри и понюхай... ну и погляди в окно минутку."),
            new StringBuilder("Обернись, там сзади баскетболист стоит... или нет")
            };
            _messageFactory = messageFactory;
            _messageFactory.Subscribe<MaximMessage>("Максим");
        }

        public string SpecialName { get; set; } = "Максим";

        public override string GetMessage(IEnumerable<StringBuilder> messageCollection, string name = null)
        {
            Random random = new Random();
                int index = random.Next(0, 6);
                var res = (StringBuilder)messageCollection.ToArray().GetValue(index);
                return res.ToString();

        }

        public string GetMessage(string name)
        {
           return GetMessage(messageCollection);
        }
    }
}
