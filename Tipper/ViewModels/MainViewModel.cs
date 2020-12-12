using DevExpress.Mvvm;
using Notification.Wpf;
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
        private bool _IsEnabled;
        public bool IsEnabled
        {
            get
            {
                if (Name != null)
                    _IsEnabled = true;
                return _IsEnabled;
            }
            set
            {
                _IsEnabled = value;
                RaisePropertyChanged();
            }
        }
        public ICommand Click => new DelegateCommand(() =>
         {
             var _messageEngine = _messageFactory.GetMessageByName(_intPutName);//generate message engine
             _notificator = new Notificator(_messageEngine.GetMessage(_intPutName)); //put generated message to notificator service

             _manager.Show(_notificator.Construct());

         });
    }
}
