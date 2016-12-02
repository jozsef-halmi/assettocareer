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
            { Cars.Abarth500RaceCar,  new CarData() {
                Name = Cars.Abarth500RaceCar
                , FriendlyName = "Abarth 500 Assetto Corse"
                , Description = "Description for Abarth 500 Assetto Corse"
            } }
           
        };
    }
}
