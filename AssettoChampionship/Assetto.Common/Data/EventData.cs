using Assetto.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Objectives;

namespace Assetto.Common.Data
{
    public class EventData
    {
        public Guid Id { get; set; }

        public string FriendlyName { get; set; }

        public TrackData Track { get; set; }

        public LayoutData Layout { get; set; }

        public PlayerData Player { get; set; }

        public List<OpponentData> Opponents { get; set; }

        public List<SessionData> GameSessions { get; set; }

        public List<SessionData> CareerSessions { get; set; }

        public JumpStartPenaltyType JumpStartPenalty { get; set; }

        public IEnumerable<Objective> EventObjectives { get; set; }


    }
}
