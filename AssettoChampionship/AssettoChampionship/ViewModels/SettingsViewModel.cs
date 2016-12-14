using Assetto.Common.Data;
using Assetto.Common.Framework;
using Assetto.Common.Interfaces.Manager;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.DTO;
using Assetto.Common.Interfaces.Service;
using Assetto.Common.Settings;
using AssettoChampionship.Services;

namespace AssettoChampionship.ViewModels
{
    public class SettingsViewModel : Screen
    {
        public IConfigManager ConfigManager { get; set; }
        public INotificationService NotificationService { get; set; }

        private AppSettings _settings;
        public AppSettings Settings {
            get
            {
                return _settings;
            }
            set
            {
                _settings = value;
                NotifyOfPropertyChange(() => Settings);
            }
        }
        public SettingsViewModel(IConfigManager configManager,
            INotificationService notificationService)
        {
            ConfigManager = configManager;
            NotificationService = notificationService;
        }

        private void RefreshData()
        {
            Settings = ConfigManager.GetSettings();
        }

        public void Save()
        {
            if (ConfigManager.SaveSettings(Settings))
            {
                NotificationService.ShowMessage("Settings have been saved.");

            }
            else
            {

            }

        }

        protected override void OnActivate()
        {
            RefreshData();
            // TODO: refresh elements
            base.OnActivate();
        }
    }

}
