using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Settings;

namespace Assetto.Common.Interfaces.Manager
{
    public interface IConfigManager
    {
        AppSettings GetSettings();
        bool SaveSettings(AppSettings settings);

        string GetSelectedPathId();
        void SetSelectedPathId(string pathId);

        bool AreSettingsValid();

        int GetDifficulty();
        void SetDifficulty(int difficulty);
    }
}
