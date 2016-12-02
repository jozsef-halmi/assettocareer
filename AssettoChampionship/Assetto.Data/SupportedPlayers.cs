using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Data
{
    public class SupportedPlayers
    {
        public static PlayerData Abarth500RaceNvidia = new PlayerData()
        {
            Car = SupportedCars.CarsDictionary[Assetto.Data.Cars.Abarth500RaceCar]
            , Skin = SupportedSkins.SkinsDictionary[Skins.Abarth500RaceCarOfficialSkin1]
        };
    }
}
