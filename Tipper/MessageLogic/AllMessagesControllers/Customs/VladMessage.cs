using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipper.MessageLogic.AllMessagesControllers.Customs
{
    public class VladMessage : AbstractMessage, IMessage
    {
        public CustomMessageFactory _factory;

        public VladMessage(CustomMessageFactory factory)
        {
            _factory = factory;
            messageCollection = new List<StringBuilder>()
            {
                new StringBuilder(", а твоим глазам нужно отдохнуть минутку").Insert(0,SpecialName),
                 new StringBuilder("хватит дуть, дай глазам отдохнуть"),
                  new StringBuilder(" Погляди в окно минутку, не благодари."),
                   new StringBuilder(", моргни?"),
                    new StringBuilder(" Боги смерти любят яблоки, а глаза любят отдыхать"),
                     new StringBuilder("Топ 1 Osu игроки часто дают глазам передохнуть"),
                      new StringBuilder("Соси соси! Ну или проморгайся хотя бы хорошенько"),
                       new StringBuilder("Одна минута отдыха глаз = -1минута жизни Адольфовны"),
                        new StringBuilder("Закрой глаза на минуту и получи шаринган, отвечаю..."),
                         new StringBuilder("Отдохнувшие глаза - залог сипловского аима.")
            };

            _factory.Subscribe<VladMessage>(SpecialName);
        }

        public IEnumerable<StringBuilder> messageCollection { get; set; }
        public string SpecialName { get; set; } = "Влад";

        public override string GetMessage(IEnumerable<StringBuilder> messageCollection, string name = null)
        {
            Random random = new Random();
            int index = random.Next(0, 8);
            var res = (StringBuilder)messageCollection.ToArray().GetValue(index);
            return res.ToString();
        }

        public string GetMessage(string name)
        {
          return  GetMessage(messageCollection);
        }
    }
}
