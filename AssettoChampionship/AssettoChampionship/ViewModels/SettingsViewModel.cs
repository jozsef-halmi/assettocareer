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

namespace AssettoChampionship.ViewModels
{
    public class SettingsViewModel : Screen
    {
        public IConfigService ConfigService { get; set; }
        public SettingsViewModel()
        {

        }

        private void RefreshData() {
        }

        protected override void OnActivate()
        {
            RefreshData();
            // TODO: refresh elements
            base.OnActivate();
        }
    }

}
