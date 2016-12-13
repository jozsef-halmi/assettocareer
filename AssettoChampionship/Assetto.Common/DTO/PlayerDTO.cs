using Assetto.Common.ProcessedResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.DTO
{
    public class PlayerDTO : ResultPlayer
    {
        public string Car { get; set; }
        public string Skin { get; set; }
        public int Gap { get; set; }
        public string GapTimeSpan { get {
                return LapTimeHelper.LaptimeFromInt(this.Gap);
            } }
    }
}
