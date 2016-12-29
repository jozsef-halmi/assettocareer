using Assetto.Common.Framework;
using AssettoChampionship.ViewModels;
using AssettoChampionship.ViewModels.Dialog;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssettoChampionship.Services
{
    public class NavigationService : INavigationService
    {
        IEventAggregator EventAggregator { get; set; }

        public NavigationService(IEventAggregator eventAggregator)
        {
            this.EventAggregator = eventAggregator;
        }

        public void ShowNextSession() {
            this.EventAggregator.Publish(new ChangePageMessage(typeof(NextSessionViewModel), new ChangePageParameters()
            {
            }), action => { Task.Factory.StartNew(action); });
        }

        public void ShowPathSelector()
        {
            this.EventAggregator.Publish(new ChangePageMessage(typeof(PathsViewModel), new ChangePageParameters()
            {
            }), action => { Task.Factory.StartNew(action); });
        }

        public void ShowVideo(string videoUrl) {
            this.EventAggregator.Publish(new ChangePageMessage(typeof(VideoViewModel), new ChangePageParameters()
            {
                Parameter = videoUrl
            }), action => { Task.Factory.StartNew(action); });
        }
    }
}
