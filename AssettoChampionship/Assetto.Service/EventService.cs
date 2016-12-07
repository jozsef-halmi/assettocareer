using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.Enum;
using Assetto.Common.Interfaces.Service;
using Assetto.Common.ProcessedResult;

namespace Assetto.Service
{
    public class EventService : IEventService
    {
        public IConfigService ConfigService { get; set; }

        public EventService(IConfigService configService)
        {
            this.ConfigService = configService;
        }

        public void OrderGrid(EventData eventData, SessionData sessionData, Result previousResult)
        {
            if (previousResult.SessionType == SessionType.Qualifying)
            {
                var playerFinished = previousResult.QualificationResult.FirstOrDefault(p => p.IsPlayer == true).Position;
                sessionData.StartingPosition = playerFinished;

                // TODO
                previousResult

            }
            // TODO!
            //switch (eventData.EventType)
            //{
            //    //TODO: Do every possibilities
            //    case EventType.QualiTwoRacesSecondReversed:
            //        var opponentsToReverse = sessionData.Opponents.Take(10).ToList();
            //        var opponentsInTheBack = sessionData.Opponents
            //            .Where(o => opponentsToReverse.FirstOrDefault(otr => otr.Name == o.Name) == null).ToList();
            //        opponentsToReverse.Reverse();

            //        var orderedOpponents = new List<OpponentData>(opponentsToReverse);
            //        orderedOpponents.AddRange(opponentsInTheBack);
            //        sessionData.OrderedGrid = orderedOpponents;
            //        sessionData.StartingPosition = sessionData.StartingPosition > 10
            //            ? sessionData.StartingPosition
            //            : (10 - sessionData.StartingPosition + 1);
            //        break;
            //    default:
            //        break;
            //}
        }

    }
}
