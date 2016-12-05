using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Objectives
{
    public class FinishTopNObjective : Objective
    {
        public int N { get; set; }


        public static FinishTopNObjective GetFinishTopNObjective(int _n)
        {
            return new FinishTopNObjective()
            {
                N = _n
            };
        }

        public static FinishTopNObjective WinObjective = new FinishTopNObjective()
        {
            N = 1
        };
    }
}
