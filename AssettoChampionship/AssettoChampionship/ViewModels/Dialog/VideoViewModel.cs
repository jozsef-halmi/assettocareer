using Assetto.Common.Framework;
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
        public IEventAggregator EventAggregator { get; set; }

        private string _videoUrl;
        public string VideoUrl { get
            {
                return _videoUrl;
            }
            set {
                _videoUrl = value;
                NotifyOfPropertyChange(() => VideoUrl);
            }
        }

        public VideoViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }

        protected override void OnActivate()
        {
            RefreshData();
            base.OnActivate();
        }

        private void RefreshData()
        {
        }

        public void SetVideo(string videoUrl) {
            this.VideoUrl = videoUrl;
        }

        public void VideoEnd() {
            this.EventAggregator.Publish(new GoBackMessage()
         , action =>
         {
             Task.Factory.StartNew(action);
         }
        );
        }
    }
}
