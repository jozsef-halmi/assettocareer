using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;

namespace Assetto.Configurator.ConfigSections
{
    public class DriverConfig : ConfigBase
    {
        public DriverData DriverData { get; set; }

        public DriverConfig(DriverData driverData, int carId) 
        {
            this.Header = $"[CAR_{carId}]";
            this.DriverData = driverData;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("MODEL=" + this.DriverData.Car.Name);
            sb.AppendLine("MODEL_CONFIG=" + this.DriverData.CarConfig?.Name);
            sb.AppendLine("SKIN=" + this.DriverData.Skin.Name);
            sb.AppendLine("DRIVER_NAME=" + this.DriverData.Name);
            sb.AppendLine("NATIONALITY=" + this.DriverData.Nationality);

            return sb.ToString();
        }
    }
}
