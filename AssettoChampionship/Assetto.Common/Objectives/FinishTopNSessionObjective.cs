﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.Enum;
using Assetto.Common.Output;

namespace Assetto.Common.Objectives
{
    public class FinishTopNSessionObjective : SessionObjective
    {
        public int N { get; set; }

        public override bool Evaluate(SessionData sessionData, OutputLog result)
        {
            var lastSession = result.Sessions.LastOrDefault();
            if (lastSession != null)
            {

            }
            // TODO: Support multiple session events
            // TODO
            return false;
        }
    }
}