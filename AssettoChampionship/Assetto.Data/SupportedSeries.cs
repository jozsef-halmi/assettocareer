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
        public static List<SeriesData> GetAvailableSeries() {
            return new List<SeriesData>() {
               SupportedSeries.MX5Series,
               SupportedSeries.AbarthRaceSeries,
               SupportedSeries.Formula3Series
            };
        }

        public static SeriesData MX5Series = new SeriesData()
        {
            Id = "MX5EuropenSeries",
            Name = "Mx5",
            FriendlyName = "MX-5 European Cup",
            Description = "The MX-5 Europen Cup is an entry-level series, which will be your first step in your career. The series take place in European countries, such as Italy, England, Austria and Poland. The tracks are short, the opponents are tough - You are going to have some serious challenges and wheel-to-wheel fights. Good luck and have fun, driver!",
            VideoUrl = "Videos/Mx5Cup.mp4",
            Events = new List<EventData>() {
                SupportedEvents.MazdaMx5Cup_Magione,
                SupportedEvents.MazdaMx5Cup_Brands,
                SupportedEvents.MazdaMx5Cup_RedBull,
                SupportedEvents.MazdaMx5Cup_Vallelunga,
                SupportedEvents.MazdaMx5Cup_Mugello
            },
            Class = SupportedClasses.Mx5
        };

        #region NotUsed

        public static SeriesData AbarthRaceSeries = new SeriesData()
        {
            Id = "Abarth500RaceSeries"
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
            , Class = SupportedClasses.Abarth
        };

        public static SeriesData Formula3Series = new SeriesData()
        {
            Id = "Formula3Series",
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

        #endregion
    }
}
