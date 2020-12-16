using Notification.Wpf;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipper.NotificationLogic
{
    public class Notificator
    {
        private string _message;
        Random random = new Random();

        public Notificator(string message)
        {
            _message = message;
        }

        public NotificationContent Construct()
        {
            var container = new NotificationContent()
            {
                Title = "Tipper for you",
                Message = _message,
                Type = RandomTipper()
            };

            //make some logic for construct a message

            return container;
        }
 
        public NotificationType RandomTipper()
        {
            return (NotificationType)random.Next(0, 4);
        }

    }
}
