using Assetto.Common.Framework;
using Assetto.Common.Interfaces.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssettoChampionship.Services
{
    public class NotificationService : INotificationService
    {
        public IEventAggregator EventAggregator { get; private set; }


        public NotificationService(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;

        }

        public void ShowMessage(string msg)
        {
            this.EventAggregator.Publish(new NotificationMessage(msg)
           , action =>
           {
               Task.Factory.StartNew(action);
           }
          );
        }
    }
}
