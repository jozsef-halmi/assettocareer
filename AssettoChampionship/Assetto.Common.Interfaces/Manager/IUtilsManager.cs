using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.Settings;

namespace Assetto.Common.Interfaces.Manager
{
    public interface IUtilsManager
    {
        List<AboutSection> GetAboutSections();
        List<AboutSection> GetCreditSections();

    }
}
