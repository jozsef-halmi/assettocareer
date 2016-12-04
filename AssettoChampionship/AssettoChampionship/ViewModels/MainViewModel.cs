using Assetto.Common.Data;
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
        // Databinded objects
        public BindableCollection<SeriesData> AvailableSeries { get; set; }

        // Managers
        public ISeriesManager SeriesManager { get; set; }
        public IEventAggregator EventAggregator { get; set; }
        public IEventManager EventManager { get; set; }

        public MainViewModel(ISeriesManager seriesManager
            , IEventAggregator eventAggregator
            , IEventManager eventManager)
        {
            this.SeriesManager = seriesManager;
            this.AvailableSeries = new BindableCollection<SeriesData>(SeriesManager.GetAvailableSeries());
            this.EventAggregator = eventAggregator;
            this.EventManager = eventManager;

            this.EventManager.SubscribeEvents(this.ConfigurationStarted
                , this.ConfigurationEnded
                , this.ACProcessStarted
                , this.ACProcessEnded);



            // Mock



   

        }

        protected override void OnActivate()
        {
            base.OnActivate();
        }


        public void SeriesSelected(Guid seriesId)
        {
            var seriesData = AvailableSeries.First();
            var eventData = seriesData.Events.First();

            this.EventManager.StartEvent(eventData);

            //EventAggregator.Publish(new ChangePageMessage(typeof(SeriesViewModel), new ChangePageParameters())
            //    , action =>
            //    {
            //        Task.Factory.StartNew(action);
            //    });
        }

        #region callbacks

        private void ConfigurationStarted(object o)
        {
            this.EventAggregator.Publish(new OpenDialogMessage(new OpenDialogMessageParameters() {
                Text = "Config started"
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
                Text = "Config ended"
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
                Text = "AC start"
            })
           , action =>
           {
               Task.Factory.StartNew(action);
           });
        }

        private void ACProcessEnded(object o)
        {
            this.EventAggregator.Publish(new OpenDialogMessage(new OpenDialogMessageParameters()
            {
                Text = "AC ended"
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
