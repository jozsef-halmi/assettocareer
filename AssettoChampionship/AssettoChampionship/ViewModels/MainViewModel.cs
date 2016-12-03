using Assetto.Common.Data;
using Assetto.Common.Framework;
using Assetto.Common.Interfaces.Manager;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            // Mock
            var seriesData = AvailableSeries.First();
            var eventData = seriesData.Events.First();
            this.EventManager.StartEvent(eventData);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
        }


        public void SeriesSelected(Guid seriesId)
        {
            EventAggregator.Publish(new ChangePageMessage(typeof(SeriesViewModel), new ChangePageParameters())
                , action =>
                {
                    Task.Factory.StartNew(action);
                });
        }







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
