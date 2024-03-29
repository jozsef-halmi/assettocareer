﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Interfaces.Manager;
using Assetto.Common.Interfaces.Service;
using Assetto.Common.Settings;
using Newtonsoft.Json;

namespace Assetto.Manager
{
    public class ConfigManager : IConfigManager
    {
        public IConfigService ConfigService { get; set; }
        public IFileService FileService { get; set; }

        public ConfigManager(IConfigService configService,
            IFileService fileService)
        {
            this.ConfigService = configService;
            this.FileService = fileService;
        }

        public AppSettings GetSettings()
        {
            AppSettings settings;

            if (ConfigService.GetSettings() != null)
            {
                // Settings already in the memory
                settings = ConfigService.GetSettings();
            }
            else if (HasSavedSettings())
            {
                // Settings not loaded, but present
                var settingsFile = FileService.ReadFile(ConfigService.GetSettingsFilePath());
                settings = JsonConvert.DeserializeObject<AppSettings>(settingsFile);
                ConfigService.SetSettings(settings);
            }
            else
            {
                // Create new settings
                settings = ConfigService.CreateSettings();
                WriteSettingsToFile(settings);
            }
            return settings;
        }

        public bool SaveSettings(AppSettings settings)
        {
            WriteSettingsToFile(settings);
            return true;
        }

        private bool HasSavedSettings()
        {
            return FileService.FileExists(ConfigService.GetSettingsFilePath());
        }

        private bool WriteSettingsToFile(AppSettings settings) {
            FileService.WriteFile(ConfigService.GetSettingsFilePath(), 
                JsonConvert.SerializeObject(settings, Formatting.Indented));
            ConfigService.SetSettings(settings);
            return true;
        }

        public string GetSelectedPathId()
        {
            return ConfigService.GetSelectedPathId();
        }

        public void SetSelectedPathId(string pathId)
        {
            AppSettings settings = GetSettings();
            ConfigService.SetSelectedPathId(pathId);
            settings.SelectedPathId = pathId;
            WriteSettingsToFile(settings);
        }

        public bool AreSettingsValid()
        {
            return ConfigService.IsSettingsValid();
        }

        public int GetDifficulty()
        {
            return ConfigService.GetDifficulty();
        }

        public void SetDifficulty(int difficulty)
        {
            ConfigService.SetDifficulty(difficulty);
            SaveSettings(ConfigService.GetSettings());
        }
    }
}
