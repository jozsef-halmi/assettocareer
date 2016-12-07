using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.ProcessedResult;

namespace Assetto.Common.Interfaces.Service
{
    public interface IEventService
    {
        void OrderGrid(EventData eventData, SessionData sessionData, Result previousResult);
    }
}
