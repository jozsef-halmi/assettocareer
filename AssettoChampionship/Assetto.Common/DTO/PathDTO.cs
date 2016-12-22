using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.DTO
{
    public class PathDTO
    {
        public string FriendlyName { get; set; }

        public string ImageUrl => "/Images/Paths/" + PathId + ".jpg";

        public bool IsAvailable { get; set; }

        public string PathId { get; set; }

        public List<SeriesDTO> Series { get; set; }
    }
}
