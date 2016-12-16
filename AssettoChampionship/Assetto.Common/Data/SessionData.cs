using Assetto.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Objectives;
using Assetto.Common.Extensions;

namespace Assetto.Common.Data
{
    public class SessionData
    {
        public SessionData()
        {
            if (this.PrimarySessionObjectives == null)
                this.PrimarySessionObjectives = new List<SessionObjective>();

            // Default value
            TimeOfDay = TimeOfDayEnum.Time1300;
            Weather = WeatherEnum.Clear;
            DynamicTrack = DynamicTracks.Green;
            AmbientTemperature = 25;
        }

        public Guid Id { get; set; }

        public string FriendlyName { get; set; }

        public string ImageUrl
        {
            get { return "/Images/" + SessionType.GetStringValue() + ".png"; }
        }

        public SessionType SessionType { get; set; }

        // For practice, and qual
        public int? Duration { get; set; }

        // For race
        public int? Laps { get; set; }
        public int? StartingPosition { get; set; }

        public List<OpponentData> OrderedGrid { get; set; }

        //public List<OpponentData> Opponents { get; set; }

        public List<SessionObjective> PrimarySessionObjectives { get; set; }

        public List<SessionObjective> SecondarySessionObjectives { get; set; }


        public TimeOfDayEnum TimeOfDay { get; set; }

        public WeatherEnum Weather { get; set; }

        private int _ambientTemperature;
        public int AmbientTemperature {
            get {
                return _ambientTemperature;
            }
            set {
                if (value > 36)
                    _ambientTemperature = 36;
                else if (value < 10)
                    _ambientTemperature = 10;
                else
                    _ambientTemperature = value;
            }
        }

        public int RoadTemperature
        {
            get
            {
                return Convert.ToInt32(Math.Round((double)AmbientTemperature * 0.9));
            }
        }

        public DynamicTrackData DynamicTrack { get; set; }



    }
}
