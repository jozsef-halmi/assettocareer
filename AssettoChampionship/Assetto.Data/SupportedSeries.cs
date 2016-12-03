using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Data
{
    public class SupportedSeries
    {
        // return EventData here
        public static SeriesData AbarthRaceSeries = new SeriesData()
        {
            Id = Guid.NewGuid()
            , Name = "Abarth500"
            , FriendlyName = "Trofeo Abarth 500"
            , Description = "TO DO"
            , ImageUrl = ""
            , VideoUrl = ""
            , Events = new List<EventData>() {
                SupportedEvents.Abarth500RaceEvent1
            }
        };
    }
}
