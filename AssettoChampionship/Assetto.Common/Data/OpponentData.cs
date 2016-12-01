using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Data
{
    public class OpponentData
    {
        public string Name { get; set; }

        public int Level { get; set; }

        public string Nationality { get; set; }

        public SkinData Skin { get; set; }
    }
}
