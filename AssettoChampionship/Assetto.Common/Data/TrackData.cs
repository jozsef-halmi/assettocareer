using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Data
{
    public class TrackData
    {
        public string Name { get; set; }
        public string FriendlyName { get; set; }

        public List<LayoutData> Layouts { get; set; }
    }
}
