using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.DTO;
using Assetto.Common.Interfaces.Manager;
using Assetto.Common.Interfaces.Service;
using Caliburn.Micro;
using AssettoChampionship.Services;

namespace AssettoChampionship.ViewModels
{
    public class PathsViewModel : Screen
    {
        #region Data

        private List<PathDTO> _paths;

        public List<PathDTO> Paths
        {
            get { return _paths; }
            set
            {
                _paths = value;
                NotifyOfPropertyChange(() => Paths);
            }
        }

        private bool _isPathAvailable = false;
        public bool IsPathsAvailable
        {
            get { return _isPathAvailable; }
            set
            {
                _isPathAvailable = value;
                NotifyOfPropertyChange(() => IsPathsAvailable);
            }
        }

        #endregion


        private IUtilsManager UtilsManager { get; set; }
        private IPathService PathService { get; set; }
        private IConfigManager ConfigManager { get; set; }
        private INavigationService NavigationService { get; set; }

        public PathsViewModel(IUtilsManager utilsManager,
            IPathService pathService,
            IConfigManager configManager,
            INavigationService navigationService)
        {
            this.UtilsManager = utilsManager;
            this.PathService = pathService;
            this.ConfigManager = configManager;
            this.NavigationService = navigationService;
        }

        private void GetPaths()
        {
            this.Paths =  PathService.GetPaths();
            IsPathsAvailable = this.Paths != null && this.Paths.Count > 0;
        }

        public void SelectPath(string pathId)
        {
            if (this.Paths.FirstOrDefault(p => p.PathId == pathId).IsAvailable == true)
            {
                ConfigManager.SetSelectedPathId(pathId);
                NavigationService.ShowNextSession();
            }
        }

        protected override void OnActivate()
        {
            GetPaths();
            base.OnActivate();
        }
    }
}
