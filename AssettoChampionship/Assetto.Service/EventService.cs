using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.Enum;
using Assetto.Common.Interfaces.Service;

namespace Assetto.Service
{
    public class EventService : IEventService
    {
        public EventData OrderGrid(EventData eventData, SessionData sessionData)
        {
            switch (eventData.EventType)
            {
                //TODO: Do every possibilities
                case EventType.QualiTwoRacesSecondReversed:
                    var opponentsToReverse = sessionData.Opponents.Take(10).ToList();
                    var opponentsInTheBack = sessionData.Opponents
                        .Where(o => opponentsToReverse.FirstOrDefault(otr => otr.Name == o.Name) == null).ToList();
                    opponentsToReverse.Reverse();

                    var orderedOpponents = new List<OpponentData>(opponentsToReverse);
                    orderedOpponents.AddRange(opponentsInTheBack);
                    sessionData.OrderedGrid = orderedOpponents;
                    sessionData.StartingPosition = sessionData.StartingPosition > 10
                        ? sessionData.StartingPosition
                        : (10 - sessionData.StartingPosition + 1);
                    break;
                default:
                    break;
            }

            return eventData;
        }


    }
}
