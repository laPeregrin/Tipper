using DevExpress.Mvvm;
using Microsoft.Extensions.DependencyInjection;
using Notification.Wpf;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using Tipper.MessageLogic;
using Tipper.NotificationLogic;

namespace Tipper.ViewModels
{
    public class MainViewModel : BindableBase
    {
        #region dependency

        private Timer _timer;
        private NotificationManager _manager;
        private CustomMessageFactory _messageFactory;
        private Notificator _notificator;

        #endregion dependency
        public MainViewModel(CustomMessageFactory messageFactory)
        {
            _manager = new NotificationManager();
            _messageFactory = messageFactory;
        }

        private string _intPutName;
        public string Name { get { return _intPutName; } set { _intPutName = value; RaisePropertyChanged(); } }
        private bool _IsVisivle = true;
        public bool IsVisible
        {
            get
            {
                if (Name != null)
                    _IsVisivle = true;
                return _IsVisivle;
            }
            set { _IsVisivle = value; RaisePropertyChanged(); }
        }


        public ICommand Click => new DelegateCommand(() =>
        {
            var _messageEngine = _messageFactory.GetMessageByName(_intPutName);//generate message engine by userName
            _notificator = new Notificator(_messageEngine.GetMessage(_intPutName)); //put generated message to notificator service
            _timer = new Timer();
            _timer.AutoReset = true;
            _timer.Interval = 3600000;
            _timer.Elapsed += (sender, args) => { _notificator = new Notificator(_messageEngine.GetMessage(_intPutName)); _manager.Show(_notificator.Construct()); };
            _messageFactory.Dispose();
            
            Task.Run(() => _timer.Start());
            
            Task.Run(() => _manager.Show("Можешь закрывать окно "));
            //Application.Current.Shutdown();
        });
    }
}



//_notifWrapper = new NotificatorQarzWrapper(_manager, _notificator);



//StdSchedulerFactory factory = new StdSchedulerFactory();
//IScheduler scheduler = await factory.GetScheduler();


//scheduler.

//             await scheduler.Start();

//IJobDetail job = JobBuilder.Create<NotificatorQarzWrapper>()
//    .WithIdentity("job1", "group1")
//    .Build();


//ITrigger trigger = TriggerBuilder.Create()
//    .WithIdentity("trigger1", "group1")
//    .StartNow()
//    .WithSimpleSchedule(x => x
//    .WithIntervalInSeconds(1)
//    .RepeatForever())
//    .Build();
//  scheduler.ScheduleJob(job, trigger);