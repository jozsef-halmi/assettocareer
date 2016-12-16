using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;

namespace Assetto.Configurator.ConfigSections
{
    public class DynamicTrackConfig : ConfigBase
    {
        public SessionData SessionData { get; set; }
        public DynamicTrackConfig(EventData eventData, SessionData sessionData) : base(eventData)
        {
            this.Header = "DYNAMIC_TRACK";
            this.SessionData = sessionData;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            sb.AppendLine("SESSION_START="+SessionData.DynamicTrack.SessionStart);
            sb.AppendLine("SESSION_TRANSFER=" + SessionData.DynamicTrack.SessionTransfer);
            sb.AppendLine("RANDOMNESS=" + SessionData.DynamicTrack.Randomness);
            sb.AppendLine("LAP_GAIN=" + SessionData.DynamicTrack.LapGain);
            sb.AppendLine("PRESET=" + SessionData.DynamicTrack.Preset);
            return sb.ToString();
        }
    }
}
