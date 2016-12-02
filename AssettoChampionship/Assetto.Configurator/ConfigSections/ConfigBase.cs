using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Configurator.ConfigSections
{
    public class ConfigBase
    {
        public string Header { get; set; }
        public EventData EventData { get; set; }

        public ConfigBase(EventData eventData)
        {
            this.EventData = eventData;
        }

        public override string ToString()
        {
            return $"[{this.Header}]";
            //return string.Format("[{0}]", this.Header);
        }
    }
}
