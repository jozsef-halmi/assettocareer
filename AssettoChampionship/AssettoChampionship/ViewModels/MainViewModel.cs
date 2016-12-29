using Assetto.Common.Data;
using Assetto.Common.DTO;
using Assetto.Common.Framework;
using Assetto.Common.Interfaces.Manager;
using AssettoChampionship.Services;
using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AssettoChampionship.ViewModels
{
    //[Export(typeof(IShell))]
    public class MainViewModel : Screen
    {
        // Managers
        private IEventAggregator EventAggregator { get; set; }
        private IEventManager EventManager { get; set; }
        private ISeriesManager SeriesManager { get; set; }
        private IConfigManager ConfigManager { get; set; }

        private INavigationService NavigationService { get; set; }

        #region Data

        private bool _isContinueAvailable;
        public bool IsContinueAvailable { get {
                return _isContinueAvailable;
            }
            set {
                _isContinueAvailable = value;
                NotifyOfPropertyChange(() => IsContinueAvailable);
            }
        }

        #endregion

        public MainViewModel(
            IEventAggregator eventAggregator
            , IEventManager eventManager
            , ISeriesManager seriesManager
            , IConfigManager configManager
            , INavigationService navigationService)
        {
            this.EventAggregator = eventAggregator;
            this.EventManager = eventManager;
            this.SeriesManager = seriesManager;
            this.ConfigManager = configManager;
            this.NavigationService = navigationService;
            this.EventManager.SubscribeEvents(this.ConfigurationStarted
                , this.ConfigurationEnded
                , this.ACProcessStarted
                , this.ACProcessEnded);

        }

        protected override void OnActivate()
        {
            var path = this.ConfigManager.GetSelectedPathId();
            this.IsContinueAvailable = !string.IsNullOrEmpty(this.ConfigManager.GetSelectedPathId());
            base.OnActivate();
        }

        public void ContinueCareer()
        {
            if (this.IsContinueAvailable)
            {
                this.NavigationService.ShowNextSession();
            }
            else
            {

            }
        }

        public void ResetCareer()
        {
            
        }

        public void NewCareer()
        {
            this.NavigationService.ShowPathSelector();
        }


        #region callbacks

        private void ConfigurationStarted(object o)
        {
            this.EventAggregator.Publish(new OpenDialogMessage(new OpenDialogMessageParameters() {
                Text = "Configuring session..",
                ImageUrl = (string)o
            })
             , action =>
             {
                 Task.Factory.StartNew(action);
             }
            );
        }

        private void ConfigurationEnded(object o)
        {
            this.EventAggregator.Publish(new OpenDialogMessage(new OpenDialogMessageParameters()
            {
                Text = "Waiting for Assetto Corsa to start.."
            })
           , action =>
           {
               Task.Factory.StartNew(action);
           });
        }

        private void ACProcessStarted(object o)
        {
            this.EventAggregator.Publish(new OpenDialogMessage(new OpenDialogMessageParameters()
            {
                Text = "Waiting for results.."
            })
           , action =>
           {
               Task.Factory.StartNew(action);
           });
        }

        private void ACProcessEnded(object o)
        {
            this.EventAggregator.Publish(new ChangePageMessage(typeof(ResultsViewModel),new ChangePageParameters()
            {
                ACExeTerminatedDto = o as ACExeTerminatedDTO
                //Parameter = o // TODO
            })
           , action =>
           {
               Task.Factory.StartNew(action);
           });
        }

        #endregion





        string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyOfPropertyChange(() => Name);
                NotifyOfPropertyChange(() => CanSayHello);
            }
        }

        public bool CanSayHello
        {
            get { return !string.IsNullOrWhiteSpace(Name); }
        }

        public void SayHello()
        {
            MessageBox.Show(string.Format("Hello {0}!", Name)); //Don't do this in real life :)
        }
    }
}
