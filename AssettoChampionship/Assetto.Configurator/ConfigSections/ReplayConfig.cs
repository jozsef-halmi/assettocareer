using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;

namespace Assetto.Configurator.ConfigSections
{
    public class ReplayConfig : ConfigBase
    {
        public ReplayConfig(EventData eventData) 
        {
            this.Header = "REPLAY";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("FILENAME=");
            sb.AppendLine("ACTIVE=0");

            return sb.ToString();
        }
    }
}
