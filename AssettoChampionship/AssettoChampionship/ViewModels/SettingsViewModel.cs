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
using System.Windows.Controls;
using System.IO;

namespace AssettoChampionship.ViewModels
{
    public class SettingsViewModel : Screen
    {
        public IConfigManager ConfigManager { get; set; }
        public INotificationService NotificationService { get; set; }
        public IFileService FileService { get; set; }
        public IConfigService ConfigService { get; set; }
        private INavigationService NavigationService { get; set; }

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

        private bool _isACFolderValid;
        public bool IsAcFolderValid
        {
            get
            {
                return _isACFolderValid;
            }
            set
            {
                _isACFolderValid = value;
                NotifyOfPropertyChange(() => IsAcFolderValid);
            }
        }

        private bool _isDocFolderValid;
        public bool IsDocFolderValid
        {
            get
            {
                return _isDocFolderValid;
            }
            set
            {
                _isDocFolderValid = value;
                NotifyOfPropertyChange(() => IsDocFolderValid);
            }
        }


        public SettingsViewModel(IConfigManager configManager,
            INotificationService notificationService,
            IFileService fileService,
            IConfigService configService,
            INavigationService navigationService)
        {
            ConfigManager = configManager;
            NotificationService = notificationService;
            FileService = fileService;
            ConfigService = configService;
            navigationService = navigationService;
        }

        private void RefreshData()
        {
            Settings = ConfigManager.GetSettings();
            InitValidators();
        }

        public void Save()
        {
            if (!IsDocFolderValid)
            {
                DialogService.ShowMessageBox("Error! ", "Please provide a valide documents folder.");
                return;
            }
            if (!IsAcFolderValid)
            {
                DialogService.ShowMessageBox("Error! ", "Please provide a valid Assetto Corsa install location.");
                return;
            }

            if (ConfigManager.SaveSettings(Settings))
            {
                NotificationService.ShowMessage("Settings have been saved.");
                NavigationService.ShowMain();
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


        //Validation
        public void ACInstallTextChanged(ActionExecutionContext context)
        {
           var dirPath = (context.Source as TextBox).Text;
           var isValid = FileService.FileExists(dirPath
                + ConfigService.GetAcExeName());

            if (isValid)
            {
                this.IsAcFolderValid = true;
                this.Settings.AssettoCorsaInstallLoc = dirPath;
                return;
            }
            else {
                var isValidWithSeparator = FileService.FileExists(dirPath
                     + Path.DirectorySeparatorChar
                     + ConfigService.GetAcExeName());

                if (isValidWithSeparator)
                {
                    (context.Source as TextBox).Text = dirPath + Path.DirectorySeparatorChar;
                    this.Settings.AssettoCorsaInstallLoc = dirPath + Path.DirectorySeparatorChar;
                    this.IsAcFolderValid = true;
                }
                else
                {
                    this.IsAcFolderValid = false;
                }
            }
        }
        public void DocFolderTextChanged(ActionExecutionContext context)
        {
            var dirPath = (context.Source as TextBox).Text;
            var isValid = FileService.FileExists(dirPath
                 + Path.DirectorySeparatorChar
                 + ConfigService.GetOutputLogRelativePathToDocFolder());

            if (isValid)
            {
                this.IsDocFolderValid = true;
                this.Settings.DocumentsFolder = dirPath;
                return;
            }
            else
            {
                
                this.IsDocFolderValid = false;
            }
        }

        private void InitValidators()
        {
            this.IsAcFolderValid = FileService.FileExists(Settings.AssettoCorsaInstallLoc
                                        + ConfigService.GetAcExeName());
            this.IsDocFolderValid = FileService.FileExists(Settings.DocumentsFolder
                                        + Path.DirectorySeparatorChar
                                     + ConfigService.GetOutputLogRelativePathToDocFolder());

        }
    }

}
