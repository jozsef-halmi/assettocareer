using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Enum;
using Assetto.Common.Objectives;

namespace Assetto.Data
{
    public class SupportedSessionObjectives
    {
        public static SessionObjective Win = new FinishTopNSessionObjective()
        {
            N = 1
        };

        public static SessionObjective Podium = new FinishTopNSessionObjective()
        {
            N = 3
        };

        public static SessionObjective Top5 = new FinishTopNSessionObjective()
        {
            N = 5
        };

        public static SessionObjective Top8 = new FinishTopNSessionObjective()
        {
            N = 8
        };

        public static SessionObjective Top10 = new FinishTopNSessionObjective()
        {
            N = 10
        };

        public static SessionObjective BestLap = new BestLapObjective()
        {
        };
    }
}
