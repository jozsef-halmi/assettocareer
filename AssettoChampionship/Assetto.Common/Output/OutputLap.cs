﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Output
{
    public class OutputLap
    {
        public int Lap { get; set; }
        public int Car { get; set; }
        public List<int> Sectors { get; set; }
        public int Time { get; set; }
    }
}
