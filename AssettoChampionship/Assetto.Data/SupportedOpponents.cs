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
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarOrangeGrey]
                    , Car = SupportedCars.CarsDictionary[Cars.Abarth500RaceCar]
                    , Level = 100
                    },
                 new OpponentData() {
                    Name = "Kendal Buckley"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarRacing500]
                    , Car = SupportedCars.CarsDictionary[Cars.Abarth500RaceCar]
                    , Level = 100
                    },
                 new OpponentData() {
                    Name = "Erlend Braband"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarLightBlueOrange]
                    , Car = SupportedCars.CarsDictionary[Cars.Abarth500RaceCar]
                    , Level = 100
                    },
                 new OpponentData() {
                    Name = "Kurtis Nadeau"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarBlackNeon]
                    , Car = SupportedCars.CarsDictionary[Cars.Abarth500RaceCar]
                    , Level = 100
                    },
                 new OpponentData() {
                    Name = "Darell Hoyt"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarSilverRed]
                    , Car = SupportedCars.CarsDictionary[Cars.Abarth500RaceCar]
                    , Level = 100
                    }
                }
            }
        };
    }
}
