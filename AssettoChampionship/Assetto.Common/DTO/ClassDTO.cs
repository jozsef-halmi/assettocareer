using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.DTO
{
    public class ClassDTO
    {
        public string Name { get; set; }
        public string FriendlyName { get; set; }
        public string ImageUrl { get {
                return "/Images/Classes/" + this.Name + ".jpg";
            }
        }
    }
}
