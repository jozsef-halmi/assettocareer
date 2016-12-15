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
            , Description = "The Trofeo Abarth 500 Cup is an entry-level series, which will be your first step in your career. The series take place in European countries, such as Italy, England, Austria and Poland. The tracks are short, the opponents are tough - You are going to have some serious challenges and wheel-to-wheel fights. Good luck and have fun, driver!"
            , VideoUrl = "Videos/Abarth500.mp4"
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
            Description = "The Formula 3 Championship is a multi-event motor racing championship for single-seat open wheel formula racing cars that is held across Europe. The championship features drivers competing in two-litre Formula Three racing cars which conform to the technical regulations, or formula, for the championship. ",
            VideoUrl = "Videos/RSR_Formula3.mp4",
            Events = new List<EventData>() {
                SupportedEvents.Formula3PaulRicard,
                SupportedEvents.Formula3Hring,
                SupportedEvents.Formula3RedBull,
                SupportedEvents.Formula3Zandvoort,
                SupportedEvents.Formula3Spa,
            },
            Credits = new CreditsData()
            {
                ToolTip = "This car has been done by the RSR team."
                , ExternalLink = "http://www.radiators-champ.com/rsrworld/cars/rsr-formula-3/"
            }
        };

    }
}
