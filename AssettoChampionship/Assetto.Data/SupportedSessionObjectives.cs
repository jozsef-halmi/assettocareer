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

        public static SessionObjective Top10 = new FinishTopNSessionObjective()
        {
            N = 10
        };
    }
}
