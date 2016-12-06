using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.SaveGames;

namespace Assetto.Common.DTO
{
    public class SeriesDTO
    {
        public SeriesData SeriesData { get; set; }
        public SavedSeason SavedSeason { get; set; }
    }
}
