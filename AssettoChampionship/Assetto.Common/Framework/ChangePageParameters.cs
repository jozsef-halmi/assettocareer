using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;

namespace Assetto.Common.Framework
{
    public class ChangePageParameters
    {
        public SeriesData SeriesData { get; set; }
        public EventData EventData { get; set; }
        public SessionData SessionData { get; set; }
        public object Parameter { get; set; }
    }
}
