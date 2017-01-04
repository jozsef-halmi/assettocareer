using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Data
{
    public static class SupportedCars
    {
        public static Dictionary<string, CarData> CarsDictionary = new Dictionary<string, CarData>()
        {
            { CarNames.MazdaMx5Cup,  new CarData() {
                Name = CarNames.MazdaMx5Cup
                , FriendlyName = "Mazda MX-5 Cup"
                , Description = "Description for Abarth 500 Assetto Corse" }
            },
            { CarNames.Abarth500RaceCar,  new CarData() {
                Name = CarNames.Abarth500RaceCar
                , FriendlyName = "Abarth 500 Assetto Corse"
                , Description = "Description for Abarth 500 Assetto Corse" }
            },
             { CarNames.Formula3,  new CarData() {
                Name = CarNames.Formula3
                , FriendlyName = "Formula3"
                , Description = "Description for Formula3" }
            }

        };
    }
}
