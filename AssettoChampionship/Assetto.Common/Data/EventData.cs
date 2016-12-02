﻿using Assetto.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Data
{
    public class EventData
    {
        public TrackData Track { get; set; }

        public LayoutData Layout { get; set; }

        public PlayerData Player { get; set; }

        //public CarData Car { get; set; }

        //public SkinData Skin { get; set; }

        //public CarConfigData CarConfig { get; set; }

        public List<OpponentData> Opponents { get; set; }

        public EventType Type { get; set; }

        public JumpStartPenaltyType JumpStartPenalty { get; set; }

        public int LapCount { get; set; }

    }
}
