﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.Enum;
using Assetto.Common.Output;
using Assetto.Common.ProcessedResult;

namespace Assetto.Common.Objectives
{
    public class LapTimeUnderObjective : SessionObjective
    {
        public int ChallengeTime { get; set; }


        protected override bool EvaluatePractice(Result result)
        {
            // Should be the same as qualify
            return this.EvaluateQualify(result);
        }

        protected override bool EvaluateQualify(Result result)
        {
            return HasALapTimeUnder(this.ChallengeTime, result.QualificationResult);
        }

        protected override bool EvaluateRace(Result result)
        {
            return HasALapTimeUnder(this.ChallengeTime, result.RaceResult);
        }

        private bool HasALapTimeUnder(int challengeTime, List<ResultPlayer> resultPlayers)
        {
            // Car with ID 0 is controlled by the Player
            var player = resultPlayers.FirstOrDefault(c => c.Id == 0);
            return player.BestLap < ChallengeTime;
        }
    }
}
