using Assetto.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Data
{
    public class ClassPathData
    {
        public string Name { get; set; }
        public string FriendlyName { get; set; }

        public string ImageUrl
        {
            get { return "/Images/Classes/" + Name + ".jpg"; }
        }

        public string Description { get; set; }
        public string VideoUrl { get; set; }

        public List<SeriesData> Series { get; set; }

        public Guid ClassPathId { get; set; }
    }
}
