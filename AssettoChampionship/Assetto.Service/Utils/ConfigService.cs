using Assetto.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.SaveGames;
using Assetto.Common.Settings;
using Newtonsoft.Json;

namespace Assetto.Service.Utils
{
    public class ConfigService : IConfigService
    {
        public const string ACS_EXE_X64 = "acs.exe";
        public const string ACS_EXE_X86 = "acs_x86.exe";
        public const string SETTINGS_FILE = "settings.acc";


        string DocumentsFolder { get; set; }
        string RaceIniRelativePathToDocFolder { get; set; }
        string OutputLogRelativePathToDocFolder { get; set; }
        string AssettoCorsaInstallLoc { get; set; }
        string AssettoCorsaExeRelativePathToACFolder { get; set; }

        public string PlayerName { get; set; }

        public IFileService FileService { get; set; }


        public ConfigService(IFileService fileService)
        {
            this.FileService = fileService;
            this.RaceIniRelativePathToDocFolder = "Assetto Corsa\\cfg\\race.ini";
            this.OutputLogRelativePathToDocFolder = "Assetto Corsa\\out\\race_out.json";
            this.AssettoCorsaInstallLoc = "e:\\Games\\Steam\\steamapps\\common\\assettocorsa\\";
            this.AssettoCorsaExeRelativePathToACFolder = "AssettoCorsa.exe";


            var savedSettings = GetSavedSettings();
            this.AssettoCorsaInstallLoc = savedSettings.AssettoCorsaInstallLoc
                        ?? "C:\\Program Files (x86)\\Steam\\SteamApps\\common\\assettocorsa";
            this.DocumentsFolder = savedSettings.DocumentsFolder 
                        ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.PlayerName = savedSettings.PlayerName ?? "Player";

        }

        private AppSettings GetSavedSettings()
        {
            AppSettings appsettings = null;
            try
            {
                var file = FileService.ReadFile(ConfigService.SETTINGS_FILE);
                appsettings = JsonConvert.DeserializeObject<AppSettings>(file);
            }
            catch (Exception)
            {
                appsettings = new AppSettings();
            }
            return appsettings;

        }

        private void SaveSettings(AppSettings settings)
        {
            FileService.WriteFile(ConfigService.SETTINGS_FILE, JsonConvert.SerializeObject(settings));
        }

        public string GetRaceIniPath() {
                return GetFolderWithSeparatorAtEnd(DocumentsFolder) + RaceIniRelativePathToDocFolder;
        }
        public string GetOutputLogPath() {
                return GetFolderWithSeparatorAtEnd(DocumentsFolder) + OutputLogRelativePathToDocFolder;
        }
        public string GetAssettoCorsaExeLoc() {
                return GetFolderWithSeparatorAtEnd(AssettoCorsaInstallLoc) + AssettoCorsaExeRelativePathToACFolder;
        }

        private string GetFolderWithSeparatorAtEnd(string basePath) {
            if (basePath.EndsWith("" + Path.DirectorySeparatorChar))
                return basePath;
            else
                return basePath + Path.DirectorySeparatorChar;
        }

        public void SetAcFolder(string acFolderPath)
        {
            this.AssettoCorsaInstallLoc = acFolderPath;
        }

        public string GetAcX86ProcessName()
        {
            return ConfigService.ACS_EXE_X86;
        }

        public string GetAcX64ProcessName()
        {
            return ConfigService.ACS_EXE_X64;

        }

        public string GetPlayerName()
        {
            return this.PlayerName;
        }
    }
}
