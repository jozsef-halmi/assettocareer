using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Data
{
    public static class SupportedTracks
    {
        public static Dictionary<string, TrackData> TracksDictionary = new Dictionary<string, TrackData>()
        {
            { Assetto.Data.Tracks.Magione, new TrackData() { Name = "magione", FriendlyName = "Magione" }
            }
        };
    }
}
