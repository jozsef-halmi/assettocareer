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
                        PathId = "Path_OW",
                        FriendlyName = "Open Wheel"
                    },
                 new PathData()
                    {
                        PathId = "Path_CW",
                        FriendlyName = "Closed Wheel",
                        IsReadyToPlay = true,
                        Series = new List<SeriesData>() {
                            SupportedSeries.PorscheGT4Series,
                            SupportedSeries.MX5Series,
                        }
                    },
                  new PathData()
                    {
                        PathId = "Path_Historic",
                        FriendlyName = "Historic",
                        IsReadyToPlay = false,
                    }
            };
        }
    }
}
