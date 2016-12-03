using Assetto.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Configurator.ConfigSections
{
    public class RaceConfig : ConfigBase
    {
        public RaceConfig(EventData eventData): base (eventData)
        {
            this.Header = "RACE";
        }



        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("TRACK=" + this.EventData.Track.Name);
            sb.AppendLine("CONFIG_TRACK=" + this.EventData.Layout?.Name);
            sb.AppendLine("MODEL=" + this.EventData.Player.Car.Name);
            sb.AppendLine("MODEL_CONFIG=" + this.EventData.Player.CarConfig?.Name);
            sb.AppendLine("CARS=" + (this.EventData.Opponents.Count + 1));
            sb.AppendLine("AI_LEVEL=100");
            sb.AppendLine("FIXED_SETUP=0");
            sb.AppendLine("PENALTIES=1");
            //sb.AppendLine("JUMP_START_PENALTY=" + this.EventData.JumpStartPenalty);

            //sb.AppendLine("SKIN=" + this.EventData.Player.Skin.Name);

            //sb.AppendLine("DRIFT_MODE=0");
            //sb.AppendLine("AI_CLASS=open");
            //sb.AppendLine("ARM_FIRST_LAP = 0");
            //sb.AppendLine("KEY=-1");

            return sb.ToString();
        }


    }
//    [RACE]
//    TRACK=ks_barcelona
//    CONFIG_TRACK = layout_moto
//MODEL=ks_porsche_911_gt3_rs
//MODEL_CONFIG =
//CARS = 1
//AI_LEVEL=90
//FIXED_SETUP=0
//PENALTIES=1
//SKIN=nvidia
//DRIFT_MODE = 0
//RACE_LAPS=0
//JUMP_START_PENALTY=2
//AI_CLASS=open
//ARM_FIRST_LAP = 0
//KEY=-1
}
