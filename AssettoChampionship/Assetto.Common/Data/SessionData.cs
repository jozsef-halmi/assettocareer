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
        public Guid Id { get; set; }

        public string FriendlyName { get; set; }

        public string ImageUrl
        {
            get { return "/Images/" + SessionType.GetStringValue() + ".jpg"; }
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



    }
}
