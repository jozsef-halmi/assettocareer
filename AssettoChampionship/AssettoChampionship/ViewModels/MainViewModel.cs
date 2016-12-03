using Assetto.Common.Data;
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
    public class MainViewModel : PropertyChangedBase
    {
        // Databinded objects
        public BindableCollection<SeriesData> AvailableSeries { get; set; }

        // Managers
        public ISeriesManager SeriesManager { get; set; }

        public MainViewModel(ISeriesManager seriesManager)
        {
            this.SeriesManager = seriesManager;
            this.AvailableSeries = new BindableCollection<SeriesData>(SeriesManager.GetAvailableSeries());
        }


        public void SeriesSelected(Guid seriesId)
        {
            this.NavigationService.Navigate(new Uri("Pages/Page2.xaml", UriKind.Relative));
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
