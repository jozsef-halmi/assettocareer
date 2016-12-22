using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.DTO
{
    public class PathDTO
    {
        public string Name { get; set; }
        public string FriendlyName { get; set; }

        public string ImageUrl => "/Images/Paths/" + Name + ".jpg";
    }
}
