using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;

namespace Assetto.Configurator.ConfigSections
{
    public class OpponentConfig : DriverConfig
    {
        public OpponentConfig(OpponentData opponentData, int carId) : base(opponentData, carId)
        {
            
        }

        public override string ToString()
        {
            var opponentData = this.DriverData as OpponentData;
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine("AI_LEVEL=" + opponentData.Level);
            return sb.ToString();
        }
    }
}
