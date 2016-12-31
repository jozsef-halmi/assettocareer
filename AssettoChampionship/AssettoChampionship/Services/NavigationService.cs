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

        public void ShowMain()
        {
            ParameterlessNavigation(typeof(MainViewModel));
        }

        public void ShowSettings()
        {
            ParameterlessNavigation(typeof(SettingsViewModel));
        }

        public void ShowNextSession() {
            ParameterlessNavigation(typeof(NextSessionViewModel));
        }

        public void ShowPathSelector()
        {
            ParameterlessNavigation(typeof(PathsViewModel));
        }

        public void ShowVideo(string videoUrl) {
            this.EventAggregator.Publish(new ChangePageMessage(typeof(VideoViewModel), new ChangePageParameters()
            {
                Parameter = videoUrl
            }), action => { Task.Factory.StartNew(action); });
        }

        private void ParameterlessNavigation(Type vmType) {
            this.EventAggregator.Publish(new ChangePageMessage(vmType, new ChangePageParameters()
            {
            }), action => { Task.Factory.StartNew(action); });
        }

        public void ShowResults()
        {
            throw new NotImplementedException();
        }

        public void ShowStandings()
        {
            ParameterlessNavigation(typeof(StandingsViewModel));
        }
    }
}
