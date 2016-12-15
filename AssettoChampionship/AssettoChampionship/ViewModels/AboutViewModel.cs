using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.Interfaces.Manager;
using Caliburn.Micro;

namespace AssettoChampionship.ViewModels
{
    public class AboutViewModel : Screen
    {
        public IUtilsManager UtilsManager { get; set; }

        private List<AboutSection> _aboutSections;

        public List<AboutSection> AboutSections {
            get
            {
                return _aboutSections;
            }
            set
            {
                _aboutSections = value;
                NotifyOfPropertyChange(() => AboutSections);
            }
        }

        private List<AboutSection> _creditSections;

        public List<AboutSection> CreditSections
        {
            get
            {
                return _creditSections;
            }
            set
            {
                _creditSections = value;
                NotifyOfPropertyChange(() => CreditSections);
            }
        }

        public AboutViewModel(IUtilsManager utilsManager)
        {
            this.UtilsManager = utilsManager;
            this.AboutSections = UtilsManager.GetAboutSections();
            this.CreditSections = UtilsManager.GetCreditSections();
        }
    }
}
