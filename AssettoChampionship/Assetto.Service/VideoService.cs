using Assetto.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Service
{
    public class VideoService : IVideoService
    {
        public List<string> WatchedUrls { get; set; }

        public VideoService()
        {
            this.WatchedUrls = new List<string>();
        }

        public bool IsVideoAlreadyWatched(string videoUrl)
        {
            return WatchedUrls.FirstOrDefault(s => s == videoUrl) != null;
        }

        public void VideoWatched(string videoUrl)
        {
            WatchedUrls.Add(videoUrl);
        }
    }
}
