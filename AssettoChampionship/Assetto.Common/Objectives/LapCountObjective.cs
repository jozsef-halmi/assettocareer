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
    public class LapCountObjective : SessionObjective
    {
        public int ChallengedLapCount { get; set; }
        protected override bool EvaluatePractice(Result result)
        {
            // Should be the same as qualify
            return this.EvaluateQualify(result);
        }

        protected override bool EvaluateQualify(Result result)
        {
            return Eval(this.ChallengedLapCount, result.Players);
        }

        protected override bool EvaluateRace(Result result)
        {
            return Eval(this.ChallengedLapCount, result.Players);
        }

        private bool Eval(int percentage, List<ResultPlayer> resultPlayers)
        {
            var player = resultPlayers.FirstOrDefault(c => c.Id == 0);
            return player.LapCount >= ChallengedLapCount;
        }

        public override string ToString()
        {
            return $"Complete {this.ChallengedLapCount} laps";
        }
    }
}
