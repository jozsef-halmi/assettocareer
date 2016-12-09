using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.DTO;

namespace Assetto.Common.Framework
{
    public class ChangePageParameters
    {
        //public SeriesData SeriesData { get; set; }

        //public EventData EventData { get; set; }

        public Guid SelectedSeriesId { get; set; }
        public Guid SelectedEventId { get; set; }


        public SessionData SessionData { get; set; }

        public ACExeTerminatedDTO ACExeTerminatedDto { get; set; }
        

        // Any other
        public object Parameter { get; set; }
    }
}
