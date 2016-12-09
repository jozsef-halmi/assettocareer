using Assetto.Common.Data;
using Assetto.Common.Framework;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.DTO;
using Assetto.Common.Interfaces.Manager;

namespace AssettoChampionship.ViewModels
{
    public class EventsViewModel : Screen
    {
        #region Properties

        private SeriesDTO _series;
        public SeriesDTO Series {
            get
            {
                return _series;
            }
            set
            {
                _series = value;
                NotifyOfPropertyChange(() => Series);
            }
        }



        #endregion


        //public Guid SelectedSeriesId { get; set; }

        //private Guid _selectedSeriesId;

            //public Guid SelectedSeriesId {
            //    get
            //    {
            //        return _selectedSeriesId;
            //    }
            //    set
            //    {
            //        _selectedSeriesId = value;
            //        NotifyOfPropertyChange(() => SelectedSeriesId);
            //    }
            //}

            #region BindedProperties

        //private string _title;

        //public string Title
        //{
        //    get { return _title; }
        //    set
        //    {
        //        _title = value;
        //        NotifyOfPropertyChange(() => Title);
        //    }
        //}

        //private string _description;

        //public string Description
        //{
        //    get { return _description; }
        //    set
        //    {
        //        _description = value;
        //        NotifyOfPropertyChange(() => Description);
        //    }
        //}

        private BindableCollection<EventData> _events { get; set; }
        public BindableCollection<EventData> Events
        {
            get { return _events; }
            set
            {
                _events = value;
                NotifyOfPropertyChange(() => Events);
            }
        }

        #endregion

        #region Injected

        // Managers
        public IEventAggregator EventAggregator { get; set; }
        public ISeriesManager SeriesManager { get; set; }

        #endregion

        public EventsViewModel(IEventAggregator eventAggregator
            , ISeriesManager seriesManager)
        {
            this.EventAggregator = eventAggregator;
            this.SeriesManager = seriesManager;
        }

        public void SetSeries(Guid seriesId)
        {
            this.Series = SeriesManager.GetSeries(seriesId);
        }

        public void EventSelected(Guid eventId)
        {
            this.EventAggregator.Publish(new ChangePageMessage(typeof(SessionsViewModel), new ChangePageParameters()
            {
                SelectedSeriesId = this.Series.SeriesId,
                SelectedEventId = eventId
            }), action => { Task.Factory.StartNew(action); });
        }


    }
}
