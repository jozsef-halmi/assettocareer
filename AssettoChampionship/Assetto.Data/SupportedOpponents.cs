﻿using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Data
{
    public class SupportedOpponents
    {

        public static List<OpponentData> EuropeanGT4Opponents = new List<OpponentData>() {
                new OpponentData() {
                    Name = "Peter TERTING"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarOrangeGrey] // TODO
                    , Car = SupportedCars.CarsDictionary[CarNames.PorscheGT4Cup]
                    , Level = 100
                    },
                 new OpponentData() {
                    Name = "Jörg VIEBAHN"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarRacing500] // TODO
                    , Car = SupportedCars.CarsDictionary[CarNames.PorscheGT4Cup]
                    , Level = 100
                    },
                 new OpponentData() {
                    Name = "Maciej DRESZER"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarLightBlueOrange] // TODO
                    , Car = SupportedCars.CarsDictionary[CarNames.MaseratiGT4]
                    , Level = 96
                    },
                 new OpponentData() {
                    Name = "Mads SILJEHAUG"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarBlackNeon] // TODO
                    , Car = SupportedCars.CarsDictionary[CarNames.MaseratiGT4]
                    , Level = 95
                    },
                 new OpponentData() {
                    Name = "Andreas PATZELT"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarSilverRed] // TODO
                    , Car = SupportedCars.CarsDictionary[CarNames.PorscheGT4Cup]
                    , Level = 95
                    },
                  new OpponentData() {
                    Name = "Nicolaj MOLLER MADSEN"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarRacing501] // TODO
                    , Car = SupportedCars.CarsDictionary[CarNames.PorscheGT4Cup]
                    , Level = 94
                    },
                   new OpponentData() {
                    Name = "Luca ANSELMI"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarRacing502] // TODO
                    , Car = SupportedCars.CarsDictionary[CarNames.MaseratiGT4]
                    , Level = 92
                    },
                    new OpponentData() {
                    Name = "Ricardo VAN DER ENDE"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarRedYellow] // TODO
                    , Car = SupportedCars.CarsDictionary[CarNames.MaseratiGT4]
                    , Level = 91
                    },
                     new OpponentData() {
                    Name = "Simon KNAP"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarMaroonWhite] // TODO
                    , Car = SupportedCars.CarsDictionary[CarNames.PorscheGT4Cup]
                    , Level = 91
                    },
                      new OpponentData() {
                    Name = "Rob SEVERS"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarZe507] // TODO
                    , Car = SupportedCars.CarsDictionary[CarNames.PorscheGT4Cup]
                    , Level = 88
                    }
                };

        public static Dictionary<string, List<OpponentData>> OpponentsDictionary = new Dictionary<string, List<OpponentData>>()
        {
            { CarNames.Abarth500RaceCar, new List<OpponentData>() {
                new OpponentData() {
                    Name = "Jazmine Hermanson"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarOrangeGrey]
                    , Car = SupportedCars.CarsDictionary[CarNames.Abarth500RaceCar]
                    , Level = 100
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
                    , Level = 88
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
            { CarNames.MazdaMx5Cup, new List<OpponentData>() {
                new OpponentData() {
                    Name = "Nathaniel Sparks"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarOrangeGrey]
                    , Car = SupportedCars.CarsDictionary[CarNames.MazdaMx5Cup]
                    , Level = 100
                    },
                 new OpponentData() {
                    Name = "Ara Malkhassian"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarRacing500]
                    , Car = SupportedCars.CarsDictionary[CarNames.MazdaMx5Cup]
                    , Level = 98
                    },
                 new OpponentData() {
                    Name = "John Dean II"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarLightBlueOrange]
                    , Car = SupportedCars.CarsDictionary[CarNames.MazdaMx5Cup]
                    , Level = 95
                    },
                 new OpponentData() {
                    Name = "Robby Foley"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarBlackNeon]
                    , Car = SupportedCars.CarsDictionary[CarNames.MazdaMx5Cup]
                    , Level = 95
                    },
                 new OpponentData() {
                    Name = "Drake Kemper"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarSilverRed]
                    , Car = SupportedCars.CarsDictionary[CarNames.MazdaMx5Cup]
                    , Level = 93
                    },
                  new OpponentData() {
                    Name = "Nikko Reger"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarRacing501]
                    , Car = SupportedCars.CarsDictionary[CarNames.MazdaMx5Cup]
                    , Level = 93
                    },
                   new OpponentData() {
                    Name = "Mark Drennan"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarRacing502]
                    , Car = SupportedCars.CarsDictionary[CarNames.MazdaMx5Cup]
                    , Level = 92
                    },
                    new OpponentData() {
                    Name = "Chris Stone"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarRedYellow]
                    , Car = SupportedCars.CarsDictionary[CarNames.MazdaMx5Cup]
                    , Level = 91
                    },
                     new OpponentData() {
                    Name = "Dean Copeland"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarMaroonWhite]
                    , Car = SupportedCars.CarsDictionary[CarNames.MazdaMx5Cup]
                    , Level = 91
                    },
                      new OpponentData() {
                    Name = "Hernan Palermo"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarZe507]
                    , Car = SupportedCars.CarsDictionary[CarNames.MazdaMx5Cup]
                    , Level = 88
                    },
                       new OpponentData() {
                    Name = "Glenn McGee"
                    , Skin = SupportedSkins.Abarth500RaceCarSkins[Skins.Abarth500RaceCarZe508]
                    , Car = SupportedCars.CarsDictionary[CarNames.MazdaMx5Cup]
                    , Level = 86
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
