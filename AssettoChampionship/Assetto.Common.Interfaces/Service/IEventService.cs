using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;

namespace Assetto.Common.Interfaces.Service
{
    public interface IEventService
    {
        EventData OrderGrid(EventData eventData, SessionData sessionData);
    }
}
