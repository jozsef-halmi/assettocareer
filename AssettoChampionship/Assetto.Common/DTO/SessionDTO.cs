using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.DTO
{
    public class SessionDTO
    {
        public Guid SessionId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public bool IsAvailable { get; set; }

        public List<ObjectiveDTO> Objectives { get; set; }


    }
}
