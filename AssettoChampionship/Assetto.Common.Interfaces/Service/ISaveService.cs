using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.ProcessedResult;

namespace Assetto.Common.Interfaces.Service
{
    public interface ISaveService
    {
        bool SaveResult(Guid seasonId, Guid eventId, Guid sessionId, Result result);

        Result LoadResult(Guid seasonId, Guid eventId, Guid sessionId);
    }
}
