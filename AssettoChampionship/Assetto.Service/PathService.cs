using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.DTO;
using Assetto.Common.Interfaces.Service;
using Assetto.Data;

namespace Assetto.Service
{
    public class PathService : IPathService
    {
        public List<PathDTO> GetPaths()
        {
            return SupportedPaths.GetPaths().Select(GetPathDTO).ToList();
        }


        private PathDTO GetPathDTO(PathData path)
        {
            return new PathDTO()
            {
                Name = path.Name,
                FriendlyName = path.FriendlyName
            };
        }
    }
}
