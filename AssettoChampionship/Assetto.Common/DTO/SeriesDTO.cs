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
        //public SeriesData SeriesData { get; set; }
        //public SavedSeason SavedSeason { get; set; }

        public Guid SeriesId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }
        public bool IsAvailable { get; set; }

        public List<EventDTO> Events { get; set; }

        public List<ChampionshipPlayerDTO> Standings { get; set; }

    }
}
