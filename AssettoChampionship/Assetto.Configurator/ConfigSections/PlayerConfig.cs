using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;

namespace Assetto.Configurator.ConfigSections
{
    public class PlayerConfig : DriverConfig
    {
        public PlayerConfig(PlayerData playerData) : base(playerData, 0)
        {
            
        }
    }
}
