﻿using Assetto.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Interfaces.Manager
{
    public interface IPathManager
    {
        PathDTO GetPath(string pathId);
        SessionDTO GetCurrentSession(string pathId);
        SeriesDTO GetCurrentSeries(string pathId);
    }
}
