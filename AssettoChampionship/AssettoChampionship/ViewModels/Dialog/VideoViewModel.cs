using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssettoChampionship.ViewModels.Dialog
{
    public class VideoViewModel : Screen
    {
        protected override void OnActivate()
        {
            RefreshData();
            base.OnActivate();
        }

        private void RefreshData()
        {
        }
    }
}
