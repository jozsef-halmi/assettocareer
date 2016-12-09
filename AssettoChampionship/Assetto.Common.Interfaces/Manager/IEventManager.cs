using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Interfaces.Manager
{
    public interface IEventManager
    {

        void StartEvent(Guid seriesId, Guid eventId, Guid sessionId);
        void SubscribeEvents(Action<object> configurationStarted, Action<object> configurationEnded, Action<object> processStarted, Action<object> processEnded);
    }
}
