using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Data
{
    public class SupportedOpponents
    {
        public static Dictionary<string, List<OpponentData>> OpponentsDictionary = new Dictionary<string, List<OpponentData>>()
        {
            { Cars.Abarth500RaceCar, new List<OpponentData>() {
                new OpponentData() {
                    Name = "Jazmine Hermanson"
                    , Skin = SupportedSkins.SkinsDictionary[Skins.Abarth500RaceCarOfficialSkin1]
                    , Car = SupportedCars.CarsDictionary[Cars.Abarth500RaceCar]
                    , Level = 100
                    },
                 new OpponentData() {
                    Name = "Kendal Buckley "
                    , Skin = SupportedSkins.SkinsDictionary[Skins.Abarth500RaceCarOfficialSkin1]
                    , Car = SupportedCars.CarsDictionary[Cars.Abarth500RaceCar]
                    , Level = 100
                    }
                }
            }
        };
    }
}
