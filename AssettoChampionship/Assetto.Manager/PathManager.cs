using Assetto.Common.Interfaces.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.DTO;
using Assetto.Data;

namespace Assetto.Manager
{
    public class PathManager : IPathManager
    {
        public ISeriesManager SeriesManager { get; set; }

        public PathManager(ISeriesManager seriesManager)
        {
            this.SeriesManager = seriesManager;
        }

        public PathDTO GetPath(string pathId) {
            var p = SupportedPaths.GetPaths().FirstOrDefault(path => path.PathId == pathId);
            return new PathDTO()
            {
                PathId = p.PathId,
                FriendlyName = p.FriendlyName,
                Series = p.Series.Select(s => SeriesManager.GetSeries(s.Id)).ToList()
            };
        }

        public SessionDTO GetNextSession(string pathId)
        {
            var path = GetPath(pathId);
            return SeriesManager.GetNextSession(
                path.Series.FirstOrDefault(s => s.IsAvailable == true && s.IsDone != true).SeriesId
                );
        }

        public SeriesDTO GetNextSeries(string pathId) {
            var path = GetPath(pathId);
            return SeriesManager.GetSeries(path.Series.FirstOrDefault(s => s.IsAvailable == true && s.IsDone != true).SeriesId);
        }
    }
}
