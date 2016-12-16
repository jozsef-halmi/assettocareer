using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Data
{
    public class DynamicTrackData
    {
        public int SessionStart { get; set; }
        public int SessionTransfer { get; set; }
        public int Randomness { get; set; }
        public int LapGain { get; set; }
        public int Preset { get; set; }
    }
}
