using Assetto.Common.Enum;
using Assetto.Common.ProcessedResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.DTO
{
    public class ResultDTO
    {
        public string Track { get; set; }
        public string Name { get; set; }
        public int PlayerPosition { get; set; }
        //public string PlayerPositionOrdinal { get }
        public SessionType SessionType { get; set; }
        public List<PlayerDTO> Players { get; set; }
        public int Duration { get; set; }
        public int LapCount { get; set; }

        public string BestLap { get
            {
                return this.Players.Where(p => p.BestLap > 0).OrderBy(p => p.BestLap).First().BestLapTimeSpan;
            }
        }
        public string BestLapOwner { get {
                return this.Players.Where(p => p.BestLap > 0).OrderBy(p => p.BestLap).First().Name;
            }
        }

    }
}
