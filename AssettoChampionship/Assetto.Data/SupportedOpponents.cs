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
            { CarNames.Abarth500RaceCar, new List<OpponentData>() {
                new OpponentData() {
                    Name = "Jazmine Hermanson"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarOrangeGrey]
                    , Car = SupportedCars.CarsDictionary[CarNames.Abarth500RaceCar]
                    , Level = 85
                    },
                 new OpponentData() {
                    Name = "Kendal Buckley"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarRacing500]
                    , Car = SupportedCars.CarsDictionary[CarNames.Abarth500RaceCar]
                    , Level = 91
                    },
                 new OpponentData() {
                    Name = "Erlend Braband"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarLightBlueOrange]
                    , Car = SupportedCars.CarsDictionary[CarNames.Abarth500RaceCar]
                    , Level = 80
                    },
                 new OpponentData() {
                    Name = "Kurtis Nadeau"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarBlackNeon]
                    , Car = SupportedCars.CarsDictionary[CarNames.Abarth500RaceCar]
                    , Level = 100
                    },
                 new OpponentData() {
                    Name = "Darell Hoyt"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarSilverRed]
                    , Car = SupportedCars.CarsDictionary[CarNames.Abarth500RaceCar]
                    , Level = 92
                    },
                  new OpponentData() {
                    Name = "Karoly Vid"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarRacing501]
                    , Car = SupportedCars.CarsDictionary[CarNames.Abarth500RaceCar]
                    , Level = 98
                    },
                   new OpponentData() {
                    Name = "Trenton Lorn"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarRacing502]
                    , Car = SupportedCars.CarsDictionary[CarNames.Abarth500RaceCar]
                    , Level = 95
                    },
                    new OpponentData() {
                    Name = "Abel Britton"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarRedYellow]
                    , Car = SupportedCars.CarsDictionary[CarNames.Abarth500RaceCar]
                    , Level = 94
                    },
                     new OpponentData() {
                    Name = "Alex Pomt"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarMaroonWhite]
                    , Car = SupportedCars.CarsDictionary[CarNames.Abarth500RaceCar]
                    , Level = 97
                    },
                      new OpponentData() {
                    Name = "Tristin Garrick"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarZe507]
                    , Car = SupportedCars.CarsDictionary[CarNames.Abarth500RaceCar]
                    , Level = 98
                    },
                       new OpponentData() {
                    Name = "Roy Freutsch"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarZe508]
                    , Car = SupportedCars.CarsDictionary[CarNames.Abarth500RaceCar]
                    , Level = 86
                    },
                        new OpponentData() {
                    Name = "Maria Fredo"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarZe509]
                    , Car = SupportedCars.CarsDictionary[CarNames.Abarth500RaceCar]
                    , Level = 97
                    },
                         new OpponentData() {
                    Name = "Vasco Orsino"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarYellowOrange]
                    , Car = SupportedCars.CarsDictionary[CarNames.Abarth500RaceCar]
                    , Level = 99
                    }
                }
            },
            { CarNames.Formula3, new List<OpponentData>() {
                new OpponentData() {
                    Name = "Tristan Cliffe"
                    , Skin = SupportedSkins.Formula3Skins[Skins.Formula3Cliffe]
                    , Car = SupportedCars.CarsDictionary[CarNames.Formula3]
                    , Level = 85
                    },
                 new OpponentData() {
                    Name = "Antonio Fuoco"
                    , Skin = SupportedSkins.Formula3Skins[Skins.Formula3Fuoco]
                    , Car = SupportedCars.CarsDictionary[CarNames.Formula3]
                    , Level = 95
                    },
                 new OpponentData() {
                    Name = "Antonio Giovinazzi"
                    , Skin = SupportedSkins.Formula3Skins[Skins.Formula3Giovinazzi]
                    , Car = SupportedCars.CarsDictionary[CarNames.Formula3]
                    , Level = 95
                    },
                 new OpponentData() {
                    Name = "Raffaele Marciello"
                    , Skin = SupportedSkins.Formula3Skins[Skins.Formula3Marciello]
                    , Car = SupportedCars.CarsDictionary[CarNames.Formula3]
                    , Level = 100
                    },
                 new OpponentData() {
                    Name = "Mario Gilles"
                    , Skin = SupportedSkins.Formula3Skins[Skins.Formula3MarioGilles]
                    , Car = SupportedCars.CarsDictionary[CarNames.Formula3]
                    , Level = 92
                    },
                  new OpponentData() {
                    Name = "Max Verstappen"
                    , Skin = SupportedSkins.Formula3Skins[Skins.Formula3Verstappen]
                    , Car = SupportedCars.CarsDictionary[CarNames.Formula3]
                    , Level = 100
                    },
                   new OpponentData() {
                    Name = "Niko Kari"
                    , Skin = SupportedSkins.Formula3Skins[Skins.Formula3ToroRoss33]
                    , Car = SupportedCars.CarsDictionary[CarNames.Formula3]
                    , Level = 95
                    },
                     new OpponentData() {
                    Name = "Sergio Sette Camara"
                    , Skin = SupportedSkins.Formula3Skins[Skins.Formula3ToroRosso55]
                    , Car = SupportedCars.CarsDictionary[CarNames.Formula3]
                    , Level = 97
                    }
                }
            }
        };
    }
}
