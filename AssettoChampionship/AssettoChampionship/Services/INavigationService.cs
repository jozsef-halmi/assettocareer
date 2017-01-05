using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.DTO;

namespace AssettoChampionship.Services
{
    public interface INavigationService
    {
        void ShowMain();
        void ShowSettings();
        void ShowNextSession();
        void ShowPathSelector();
        void ShowVideo(VideoDTO video);

        void ShowResults();
        void ShowStandings();

    }
}
