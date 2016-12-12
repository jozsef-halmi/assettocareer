using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.DTO
{
    public class EventDTO
    {
        public Guid EventId { get; set; }
        public Guid SeriesId { get; set; }


        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public bool IsAvailable { get; set; }

        public string Track { get; set; }
        public string Layout { get; set; }

        public bool IsLayoutAvailable {
            get
            {
                return !string.IsNullOrEmpty(Layout); 
            }
        }
        public int SessionsCount { get; set; }

        public List<SessionDTO> Sessions { get; set; }

    }
}
