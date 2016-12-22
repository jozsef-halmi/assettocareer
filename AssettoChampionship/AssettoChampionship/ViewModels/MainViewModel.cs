using Assetto.Common.Data;
using Assetto.Common.DTO;
using Assetto.Common.Framework;
using Assetto.Common.Interfaces.Manager;
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
        public IEventAggregator EventAggregator { get; set; }
        public IEventManager EventManager { get; set; }

        public MainViewModel(
            IEventAggregator eventAggregator
            , IEventManager eventManager)
        {
            this.EventAggregator = eventAggregator;
            this.EventManager = eventManager;

            this.EventManager.SubscribeEvents(this.ConfigurationStarted
                , this.ConfigurationEnded
                , this.ACProcessStarted
                , this.ACProcessEnded);

        }

        protected override void OnActivate()
        {
            base.OnActivate();
        }

        public void OpenSeries() {
            // this.EventAggregator.Publish(new ChangePageMessage(typeof(SeriesViewModel), new ChangePageParameters())
            // , action =>
            // {
            //     Task.Factory.StartNew(action);
            // }
            //);

            this.EventAggregator.Publish(new ChangePageMessage(typeof(NextSessionViewModel), new ChangePageParameters() {
                Parameter = "Path_GT"
            })
           , action =>
           {
               Task.Factory.StartNew(action);
           }
          );
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
