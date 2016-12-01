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
        public static List<CarData> Cars = new List<CarData>()
        {
            new CarData() {
                Name = "abarth500_s1"
                , FriendlyName = "Abarth 500 EsseEsse Step1"
                , Description = "The Step1 tuned version of Abarth500 EsseEsse has non adjustable aftermarket dampers and lowered springs and an ECU reprogramming which gives a little more boost on the turbos, gaining a fair amount of power and torque."
            }
        };
    }
}
