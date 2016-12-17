using System;
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
    public class PercentageObjective : SessionObjective
    {
        public int ChallengedPercentage { get; set; }
        protected override bool EvaluatePractice(Result result)
        {
            // Should be the same as qualify
            return this.EvaluateQualify(result);
        }

        protected override bool EvaluateQualify(Result result)
        {
            return UnderPercentage(this.ChallengedPercentage, result.Players);
        }

        protected override bool EvaluateRace(Result result)
        {
            return UnderPercentage(this.ChallengedPercentage, result.Players);
        }

        private bool UnderPercentage(int percentage, List<ResultPlayer> resultPlayers)
        {
            var bestLap = resultPlayers.OrderByDescending(rp => rp.BestLap).First().BestLap;
            // Car with ID 0 is controlled by the Player
            var player = resultPlayers.FirstOrDefault(c => c.Id == 0);
            return (player.BestLap != 0) && (player.BestLap <= bestLap*percentage);
        }

        public override string ToString()
        {
            return $"Be within the {this.ChallengedPercentage}% range";
        }
    }
}
