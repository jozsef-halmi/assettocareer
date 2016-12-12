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
            Id = new Guid("8fe421d8-3ed1-4b3a-8bd2-a32c336880dc")
            , Name = "Abarth500"
            , FriendlyName = "Trofeo Abarth 500 Series"
            , Description = "The Trofeo Abarth 500 Cup is an entry-level series. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. "
            , VideoUrl = ""
            , Events = new List<EventData>() {
                SupportedEvents.Abarth500RaceEvent1,
                SupportedEvents.Abarth500RaceEvent2,
                SupportedEvents.Abarth500RaceEvent3,
                SupportedEvents.Abarth500RaceEvent4,
                SupportedEvents.Abarth500RaceEvent5TorPoznan
            }
        };

        public static SeriesData Formula3Series = new SeriesData()
        {
            Id = new Guid("54a0417b-a320-48eb-8ce6-876a4558bb6e"),
            Name = "Formula3",
            FriendlyName = "Formula 3 Dallara F312 Series",
            Description = "Dallara F312 Series. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. Lorem ipsum. ",
            VideoUrl = "",
            Events = new List<EventData>() {
                SupportedEvents.Formula3PaulRicard,
                SupportedEvents.Formula3Hring,
                SupportedEvents.Formula3Spa,
            }
        };

    }
}
