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
               new PathData()
                    {
                       PathId = "Path_Road",
                       FriendlyName = "Road"
                    },
                new PathData()
                    {
                        PathId = "Path_Formula",
                        FriendlyName = "Formula"
                    },
                 new PathData()
                    {
                        PathId = "Path_GT",
                        FriendlyName = "GT",
                        IsReadyToPlay = true,
                        Series = new List<SeriesData>() {
                            SupportedSeries.AbarthRaceSeries
                        }
                    }
            };
        }
    }
}
