using System;
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
                // Settigns not loaded, but present
                var settingsFile = FileService.ReadFile(ConfigService.GetSettingsFilePath());
                settings = JsonConvert.DeserializeObject<AppSettings>(settingsFile);
                ConfigService.SetSettings(settings);
            }
            else
            {
                // Create new settings
                settings = ConfigService.CreateSettings();
                FileService.WriteFile(ConfigService.GetSettingsFilePath(), JsonConvert.SerializeObject(settings));
            }
            return settings;
        }

        private bool HasSavedSettings()
        {
            return FileService.FileExists(ConfigService.GetSettingsFilePath());
        }
    }
}
