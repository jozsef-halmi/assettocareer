using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.DTO
{
    public class SessionDTO
    {
        public string SessionId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int LapCount { get; set; }
        public bool IsDone { get; set; }
        public bool IsAvailable { get; set; }

        public string TrackId { get; set; }
        public string TrackImageUrl => "/Images/Tracks/" + TrackId + ".png";

        public List<ObjectiveDTO> Objectives { get; set; }
        public int FinishedPosition { get; set; }
        public bool HasResults => this.FinishedPosition > 0;

        public bool IsRace => LapCount == 0;

        public string TimeOfDay { get; set; }
        public string TrackCondition { get; set; }
        public string Weather { get; set; }
        public string AmbientTemperature { get; set; }
        public string RoadTemperature { get; set; }

        public int SessionCounterCurrent { get; set; }
        public int SessionCounterMax { get; set; }

        public int EventCounterCurrent { get; set; }
        public int EventCounterMax { get; set; }


    }
}
