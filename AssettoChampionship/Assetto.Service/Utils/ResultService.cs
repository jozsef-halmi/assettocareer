using Assetto.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Output;
using Newtonsoft.Json;

namespace Assetto.Service.Utils
{
    public class ResultService : IResultService
    {
        public EventResult GetResult(string contents)
        {
            return JsonConvert.DeserializeObject<EventResult>(contents);
        }
    }
}
