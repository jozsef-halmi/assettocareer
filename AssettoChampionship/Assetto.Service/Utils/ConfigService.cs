using Assetto.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Service.Utils
{
    public class ConfigService : IConfigService
    {
        public const string ACS_EXE_X64 = "acs.exe";
        public const string ACS_EXE_X86 = "acs_x86.exe";

        string DocumentsFolder { get; set; }
        string RaceIniRelativePathToDocFolder { get; set; }
        string OutputLogRelativePathToDocFolder { get; set; }
        string AssettoCorsaInstallLoc { get; set; }
        string AssettoCorsaExeRelativePathToACFolder { get; set; }


        public ConfigService()
        {
            this.DocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.RaceIniRelativePathToDocFolder = "Assetto Corsa\\cfg\\race.ini";
            this.OutputLogRelativePathToDocFolder = "Assetto Corsa\\out\\race_out.json";
            this.AssettoCorsaInstallLoc = "e:\\Games\\Steam\\steamapps\\common\\assettocorsa\\";
            this.AssettoCorsaExeRelativePathToACFolder = "AssettoCorsa.exe";


            //            private const string RACE_INI_PATH = "C:\\Users\\halmi\\Documents\\Assetto Corsa\\cfg\\race.ini";
            //private const string ASSETTO_CORSA_EXE_PATH = "e:\\Games\\Steam\\steamapps\\common\\assettocorsa\\AssettoCorsa.exe";
            //private const string OUTPUT_LOG_PATH = "C:\\Users\\halmi\\Documents\\Assetto Corsa\\out\\race_out.json";
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
    }
}
