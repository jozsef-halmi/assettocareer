using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.ProcessedResult;
using Assetto.Common.SaveGames;

namespace Assetto.Common.DTO
{
    public class ACExeTerminatedDTO
    {
        public ResultDTO Result { get; set; }
        public string Error { get; set; }

    }
}
