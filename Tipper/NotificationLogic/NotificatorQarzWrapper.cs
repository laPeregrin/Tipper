using Notification.Wpf;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipper.NotificationLogic
{
    public class NotificatorQarzWrapper : IJob
    {
        private readonly NotificationManager _notificationManager;
        private readonly Notificator _notificator;

        public NotificatorQarzWrapper(NotificationManager notificationManager, Notificator notificator)
        {
            _notificationManager = notificationManager;
            _notificator = notificator;
        }

        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() => _notificationManager.Show(_notificator.Construct()));
        }
    }
}
