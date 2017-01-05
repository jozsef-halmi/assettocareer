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
        public static PlayerData MazdaMx5CupPlayer = new PlayerData()
        {
            Car = SupportedCars.CarsDictionary[CarNames.MazdaMx5Cup],
            Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarOfficialSkin1] // TODO
        };

        public static PlayerData PorscheGT4Player = new PlayerData()
        {
            Car = SupportedCars.CarsDictionary[CarNames.PorscheGT4Cup],
            Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarOfficialSkin1] // TODO
        };


        public static PlayerData Abarth500RaceOfficial = new PlayerData()
        {
            Car = SupportedCars.CarsDictionary[Assetto.Data.CarNames.Abarth500RaceCar]
            , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarOfficialSkin1]
        };

        public static PlayerData Formula3 = new PlayerData()
        {
            Car = SupportedCars.CarsDictionary[Assetto.Data.CarNames.Formula3],
            Skin = SupportedSkins.Formula3Skins[Skins.Formula3MRT65]
        };
    }
}
