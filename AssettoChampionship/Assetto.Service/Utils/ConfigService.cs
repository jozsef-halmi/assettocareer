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


        //string DocumentsFolder { get; set; }
        string RaceIniRelativePathToDocFolder { get; set; }
        string OutputLogRelativePathToDocFolder { get; set; }
        //string AssettoCorsaInstallLoc { get; set; }
        string AssettoCorsaExeRelativePathToACFolder { get; set; }

        public AppSettings Settings { get; set; }

        //public string PlayerName { get; set; }

        public IFileService FileService { get; set; }



        public ConfigService(IFileService fileService)
        {
            this.RaceIniRelativePathToDocFolder = "Assetto Corsa\\cfg\\race.ini";
            this.OutputLogRelativePathToDocFolder = "Assetto Corsa\\out\\race_out.json";
            //this.AssettoCorsaInstallLoc = "e:\\Games\\Steam\\steamapps\\common\\assettocorsa\\";
            this.AssettoCorsaExeRelativePathToACFolder = "AssettoCorsa.exe";
            this.FileService = fileService;
            

        }

        public string GetSettingsFilePath()
        {
            return ConfigService.SETTINGS_FILE;
        }

        public void SetSettings(AppSettings settings)
        {
            // Default values
            this.Settings = new AppSettings()
            {
                AssettoCorsaInstallLoc = settings.AssettoCorsaInstallLoc ??
                                         "C:\\Program Files (x86)\\Steam\\SteamApps\\common\\assettocorsa",
                DocumentsFolder = settings.DocumentsFolder ??
                                  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                PlayerName = settings.PlayerName ?? "Player"
            };
        }

        public AppSettings GetSettings()
        {
            return this.Settings;
        }

        public AppSettings CreateSettings()
        {
            SetSettings(new AppSettings());
            return GetSettings();
        }


        public string GetRaceIniPath() {
                return GetFolderWithSeparatorAtEnd(Settings.DocumentsFolder) + RaceIniRelativePathToDocFolder;
        }
        public string GetOutputLogPath() {
                return GetFolderWithSeparatorAtEnd(Settings.DocumentsFolder) + OutputLogRelativePathToDocFolder;
        }
        public string GetAssettoCorsaExeLoc() {
                return GetFolderWithSeparatorAtEnd(Settings.AssettoCorsaInstallLoc) + AssettoCorsaExeRelativePathToACFolder;
        }

        public string GetAssettoFolder() {
            return GetFolderWithSeparatorAtEnd(Settings.AssettoCorsaInstallLoc);
        }

        private string GetFolderWithSeparatorAtEnd(string basePath) {
            if (basePath.EndsWith("" + Path.DirectorySeparatorChar))
                return basePath;
            else
                return basePath + Path.DirectorySeparatorChar;
        }

        public void SetAcFolder(string acFolderPath)
        {
            this.Settings.AssettoCorsaInstallLoc = acFolderPath;
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
            return this.Settings.PlayerName;
        }

        public string GetAcExeName()
        {
            return AssettoCorsaExeRelativePathToACFolder;
        }

        public string GetOutputLogRelativePathToDocFolder()
        {
            return OutputLogRelativePathToDocFolder;
        }

        public bool IsSettingsAvailable()
        {
            return FileService.FileExists(SETTINGS_FILE);
        }

        public bool IsSettingsValid()
        {
            var isAcInstallFolderValid =  FileService.FileExists(Settings.AssettoCorsaInstallLoc + GetAcExeName());
            var isDocFolderValid = FileService.FileExists(Settings.DocumentsFolder 
                + Path.DirectorySeparatorChar
                + GetOutputLogRelativePathToDocFolder());
            return isAcInstallFolderValid && isDocFolderValid;

        }
    }
}
