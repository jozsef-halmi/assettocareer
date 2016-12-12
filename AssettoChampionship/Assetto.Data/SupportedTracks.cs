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
            { Assetto.Data.TrackNames.Magione, new TrackData() { Name = "magione", FriendlyName = "Magione" }},
            { Assetto.Data.TrackNames.Brands, new TrackData() { Name = "ks_brands_hatch", FriendlyName = "Brands Hatch" }},
            { Assetto.Data.TrackNames.RedBullRing, new TrackData() { Name = "ks_red_bull_ring", FriendlyName = "Red Bull Ring" }},
            { Assetto.Data.TrackNames.Vallelunga, new TrackData() { Name = "ks_vallelunga", FriendlyName = "Vallelunga" }},
            { Assetto.Data.TrackNames.Spa, new TrackData() { Name = "spa", FriendlyName = "Circuit de Spa-Francorchamps" }},
            { Assetto.Data.TrackNames.Hungaroring, new TrackData() { Name = "hungaroring", FriendlyName = "Hungaroring" }},
            { Assetto.Data.TrackNames.PaulRicard, new TrackData() { Name = "paul_ricard", FriendlyName = "Paul Ricard" }},
            { Assetto.Data.TrackNames.TorPoznan, new TrackData() { Name = "tor_poznanl", FriendlyName = "Tor Poznań" }},
            { Assetto.Data.TrackNames.Zandvoort, new TrackData() { Name = "ks_zandvoort", FriendlyName = "Paul Ricard" }},




        };
    }
}
