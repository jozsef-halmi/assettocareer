using Assetto.Common.Framework;
using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssettoChampionship.ViewModels.Dialog
{
    public class LoadingViewModel : Screen
    {
        public bool IsOpen { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        //public IWindowManager WindowManager;
        public IDialogCoordinator DialogCoordinator { get; set; }


        public LoadingViewModel(
         
            //IWindowManager windowManager
            )
        {
   
            //this.WindowManager = windowManager;
        }

        public void UpdateData(UpdateDialogMessageParameters data) {
            this.Title = data.Title;
            this.Text = data.Text;
        }

        //public void Show() {
        //    if (!this.IsOpen)
        //    {
        //        //this.WindowManager.ShowDialog(Container.Resolve<LoadingViewModel>());

        //    }
        //}

        //public void Dismiss() {

        //}
    }
}
