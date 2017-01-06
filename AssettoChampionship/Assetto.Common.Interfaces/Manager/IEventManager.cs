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

        void StartEvent(string seriesId, string eventId, string sessionId, float difficulty, float length);
        void SubscribeEvents(Action<object> configurationStarted, Action<object> configurationEnded, Action<object> processStarted, Action<object> processEnded);
        void VideoWatched(string videoUrl);
        bool IsVideoAlreadyWatched(string videoUrl);
        int GetCalculatedSessionLength(string seriesId, string eventId, string sessionId, float lengthMultiplier);
    }
}
