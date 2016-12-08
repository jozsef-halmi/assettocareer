using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.DTO;
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

        public void OrderGrid(ConfiguredSessionDTO configuredSession)
        {
            if (configuredSession.PreviousSessionResult == null) return;

            if (configuredSession.PreviousSessionResult.SessionType == SessionType.Qualifying)
            {
                var playerFinished = configuredSession.PreviousSessionResult.Players.FirstOrDefault(p => p.IsPlayer == true).Position;
                configuredSession.SessionData.OrderedGrid = new List<OpponentData>();

                configuredSession.SessionData.StartingPosition =
                    configuredSession.PreviousSessionResult.Players.FirstOrDefault(p => p.IsPlayer == true)
                        .Position;

                var orderedPreviousGrid = configuredSession.PreviousSessionResult.Players.OrderBy(p => p.Position);

                foreach (var prevCar in orderedPreviousGrid)
                {
                    var opponent = configuredSession.EventData.Opponents.FirstOrDefault(o => o.Name == prevCar.Name);
                    if (opponent != null)
                        configuredSession.SessionData.OrderedGrid.Add(opponent);
                }

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
