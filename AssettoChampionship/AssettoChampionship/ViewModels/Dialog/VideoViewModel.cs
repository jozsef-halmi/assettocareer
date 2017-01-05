using Assetto.Common.Framework;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.DTO;

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

        private string _videoMsg;
        public string VideoMsg
        {
            get
            {
                return _videoMsg;
            }
            set
            {
                _videoMsg = value;
                NotifyOfPropertyChange(() => VideoMsg);
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

        public void SetVideo(VideoDTO video) {
            this.VideoUrl = video.Url;
            this.VideoMsg = video.Message;
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
