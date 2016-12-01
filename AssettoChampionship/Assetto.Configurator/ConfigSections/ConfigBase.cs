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

        public override string ToString()
        {
            return string.Format("[{0}]", this.Header);
        }
    }
}
