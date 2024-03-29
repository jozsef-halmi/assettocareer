﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Settings;

namespace Assetto.Common.Interfaces.Service
{
    public interface IConfigService
    {

        string GetRaceIniPath();
        string GetOutputLogPath();
        string GetAssettoCorsaExeLoc();
        string GetAssettoFolder();
        string GetAcExeName();
        string GetOutputLogRelativePathToDocFolder();
        void SetAcFolder(string acFolderPath);
        string GetAcX86ProcessName();
        string GetAcX64ProcessName();
        string GetPlayerName();
        string GetSelectedPathId();
        void SetSelectedPathId(string pathId);

        string GetSettingsFilePath();

        void SetSettings(AppSettings settings);
        AppSettings GetSettings();
        AppSettings CreateSettings();
        bool IsSettingsAvailable();
        bool IsSettingsValid();

        int GetDifficulty();
        void SetDifficulty(int difficulty);
    }
}
