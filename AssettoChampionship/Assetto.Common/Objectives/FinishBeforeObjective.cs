using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.Output;
using Assetto.Common.ProcessedResult;

namespace Assetto.Common.Objectives
{
    public class FinishBeforeObjective : SessionObjective
    {
        public string Name { get; set; }


        protected override bool EvaluatePractice(Result result)
        {
            // should be the same as qualy
            return this.EvaluateQualify(result);
        }

        protected override bool EvaluateQualify(Result result)
        {
            return FinishedBefore(this.Name, result.Players);
        }

        protected override bool EvaluateRace(Result result)
        {
            return FinishedBefore(this.Name, result.Players);

        }

        private bool FinishedBefore(string opponentName, List<ResultPlayer> resultPlayers)
        {
            // Car with ID 0 is controlled by the Player
            var playerFinished = resultPlayers.IndexOf(
                resultPlayers.FirstOrDefault(c => c.Id == 0)
            ) + 1; // Because, you can't finish 0th

            if (resultPlayers.IndexOf(
                    resultPlayers.FirstOrDefault(c => c.Name == opponentName)
                ) < 0)
            {
                throw new ArgumentException("No opponent named "+opponentName);
            }

            var opponentFinished = resultPlayers.IndexOf(
                resultPlayers.FirstOrDefault(c => c.Name == opponentName)
            ) + 1; // Because, you can't finish 0th

            return playerFinished < opponentFinished;
        }
    }
}
