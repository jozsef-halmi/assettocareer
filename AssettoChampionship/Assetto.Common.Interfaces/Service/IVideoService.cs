using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Interfaces.Service
{
    public interface IVideoService
    {
        void VideoWatched(string videoUrl);
        bool IsVideoAlreadyWatched(string videoUrl);
    }
}
