using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssettoChampionship.ViewModels
{
    public class SessionsViewModel : PropertyChangedBase
    {
        public IEventAggregator EventAggregator { get; set; }

        public SessionsViewModel(IEventAggregator eventAggregator)
        {
            this.EventAggregator = eventAggregator;
        }


    }
}
