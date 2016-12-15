using Assetto.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Data
{
    public class SeriesData
    {
        public string Name { get; set; }
        public string FriendlyName { get; set; }

        public string ImageUrl
        {
            get { return "/Images/Series/" + Name + ".jpg"; }
        }

        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public List<EventData> Events { get; set; }
        public Guid Id { get; set; }

        public ChampionshipPointType ChampionshipPointType { get; set; }

        public CreditsData Credits { get; set; }

    }
}
