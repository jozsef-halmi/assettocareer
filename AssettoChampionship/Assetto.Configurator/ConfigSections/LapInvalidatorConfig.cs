using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;

namespace Assetto.Configurator.ConfigSections
{
    public class LapInvalidatorConfig : ConfigBase
    {
        public LapInvalidatorConfig(EventData eventData) : base(eventData)
        {
            this.Header = "LAP_INVALIDATOR";
        }

        public override string ToString()
        {
            // TODO: ENABLE SETTING THESE VALUES
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ALLOWED_TYRES_OUT=2");
            return sb.ToString();
        }
    }
}
