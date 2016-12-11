using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.Enum;
using Assetto.Common.Output;
using Assetto.Common.ProcessedResult;
using Assetto.Common.Extensions;

namespace Assetto.Common.Objectives
{
    public class FinishTopNSessionObjective : SessionObjective
    {
        public int N { get; set; }


        protected override bool EvaluatePractice(Result result)
        {
            // Should be the same as qualify
            return this.EvaluateQualify(result);
        }

        protected override bool EvaluateQualify(Result result)
        {
            return FinishedTopN(this.N, result.Players);
        }

        protected override bool EvaluateRace(Result result)
        {
            return FinishedTopN(this.N, result.Players);
        }

        private bool FinishedTopN(int N, List<ResultPlayer> resultPlayers)
        {
            // Car with ID 0 is controlled by the Player
            var finished = resultPlayers.IndexOf(
                resultPlayers.FirstOrDefault(c => c.Id == 0)
            ) + 1; // Because, you can't finish 0th
            return finished <= N;
        }

        public override string ToString()
        {
            return "Finish " + Ordinal.AddOrdinal(this.N) + " or better";
        }
    }
}
