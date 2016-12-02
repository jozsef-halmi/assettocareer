using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Data
{
    public class SupportedSkins
    {
        public static Dictionary<string, SkinData> SkinsDictionary = new Dictionary<string, SkinData>()
        {
            { Skins.Abarth500RaceCarOfficialSkin1, new SkinData() {
                Name = Skins.Abarth500RaceCarOfficialSkin1, FriendlyName = "Official 0" }
            }
        };
        
    }
}
