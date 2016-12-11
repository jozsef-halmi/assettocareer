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
    public class LoadingViewModel : PropertyChangedBase
    {
        public bool IsOpen { get; set; }


        string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        string _text;

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                NotifyOfPropertyChange(() => Text);
            }
        }


        string _imageUrl;

        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                NotifyOfPropertyChange(() => ImageUrl);
            }
        }

        public LoadingViewModel()
        {
        }

        public void UpdateData(string text, string imageUrl) {
            //this.Title = data.Title;
            this.Text = text;

            if (!string.IsNullOrEmpty(imageUrl))
                this.ImageUrl = imageUrl;
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
