﻿using Assetto.Common.DTO;
using Assetto.Common.Enum;
using Assetto.Common.ProcessedResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Interfaces.Service
{
    public interface IChampionshipService
    {
        List<ChampionshipPlayerDTO> GetCurrentStandings(string seriesId);
        List<ChampionshipPlayerDTO> GetPointsForResult(Result result, SessionType sessionType, ChampionshipPointType pointType);

        int GetPlayerChampionshipPosition(string seriesId);
        bool IsPlayerWinning(string seriesId);
    }
}
