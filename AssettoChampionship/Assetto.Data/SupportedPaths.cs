using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Data
{
    public class SupportedPaths
    {
        public static List<PathData> GetPaths()
        {
            return new List<PathData>() {
                RoadPath,
                FormulaPath,
                GTPath
            };
        }


        public static PathData RoadPath = new PathData()
        {
           Name = "Path_Road",
           FriendlyName = "Road"
        };

        public static PathData FormulaPath = new PathData()
        {
            Name = "Path_Formula",
            FriendlyName = "Formula"
        };

        public static PathData GTPath = new PathData()
        {
            Name = "Path_GT",
            FriendlyName = "GT"
        };

        //public static SeriesData Formula3Series = new SeriesData()
        //{
        //    Id = "Formula3Series",
        //    Name = "Formula3",
        //    FriendlyName = "Formula 3 Dallara F312 Series",
        //    Description = "The Formula 3 Championship is a multi-event motor racing championship for single-seat open wheel formula racing cars that is held across Europe. The championship features drivers competing in two-litre Formula Three racing cars which conform to the technical regulations, or formula, for the championship. ",
        //    VideoUrl = "Videos/RSR_Formula3.mp4",
        //    Events = new List<EventData>() {
        //        SupportedEvents.Formula3PaulRicard,
        //        SupportedEvents.Formula3Hring,
        //        SupportedEvents.Formula3RedBull,
        //        SupportedEvents.Formula3Zandvoort,
        //        SupportedEvents.Formula3Spa,
        //    },
        //    Credits = new CreditsData()
        //    {
        //        ToolTip = "This car has been done by the RSR team."
        //        , ExternalLink = "http://www.radiators-champ.com/rsrworld/cars/rsr-formula-3/"
        //    }
        //};

    }
}
