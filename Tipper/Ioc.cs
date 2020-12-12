using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipper.MessageLogic;
using Tipper.MessageLogic.AllMessagesControllers._default;
using Tipper.MessageLogic.AllMessagesControllers.Customs;
using Tipper.ViewModels;

namespace Tipper
{
    public class Ioc
    {
        public static ServiceProvider _provider;
        
        public static void Init()
        {
            var services = new ServiceCollection();

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<CustomMessageFactory>();
            services.AddSingleton<MessageDefault>();
            services.AddSingleton<MaximMessage>();

            _provider = services.BuildServiceProvider();

            foreach(var i in services)
            {
                _provider.GetRequiredService(i.ServiceType);
            }
        }

        public MainViewModel MainViewModel => _provider.GetRequiredService<MainViewModel>();
    }
}
