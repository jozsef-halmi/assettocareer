using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.Interfaces.Manager;
using Assetto.Data;

namespace Assetto.Manager
{
    public class UtilsManager : IUtilsManager
    {
        public List<AboutSection> GetAboutSections() => AboutData.AboutSections;

        public List<AboutSection> GetCreditSections() => AboutData.CreditSections;
    }
}
