using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Settings
{
    public class AppSettings
    {
        string DocumentsFolder { get; set; }
        string RaceIniRelativePathToDocFolder { get; set; }
        string OutputLogRelativePathToDocFolder { get; set; }
        string AssettoCorsaInstallLoc { get; set; }
        string AssettoCorsaExeRelativePathToACFolder { get; set; }
    }
}
