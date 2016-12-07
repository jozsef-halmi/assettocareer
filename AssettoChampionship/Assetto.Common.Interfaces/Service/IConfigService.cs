using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Interfaces.Service
{
    public interface IConfigService
    {

        string GetRaceIniPath();
        string GetOutputLogPath();
        string GetAssettoCorsaExeLoc();
        void SetAcFolder(string acFolderPath);
        string GetAcX86ProcessName();
        string GetAcX64ProcessName();
        string GetPlayerName();
    }
}
