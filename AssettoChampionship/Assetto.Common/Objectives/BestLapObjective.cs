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
    public class BestLapObjective : SessionObjective
    {
        protected override bool EvaluatePractice(Result result)
        {
            // Should be the same as qualify
            return this.EvaluateQualify(result);
        }

        protected override bool EvaluateQualify(Result result)
        {
            return DoBestLap(result.Players);
        }

        protected override bool EvaluateRace(Result result)
        {
            return DoBestLap(result.Players);
        }

        private bool DoBestLap(List<ResultPlayer> resultPlayers)
        {
            // Car with ID 0 is controlled by the Player
            var player = resultPlayers.FirstOrDefault(c => c.Id == 0);
            return resultPlayers.Any(rp => rp.BestLap < player.BestLap);
        }

        public override string ToString()
        {
            return "Do the best lap";
        }
    }
}
