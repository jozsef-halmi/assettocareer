using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.DTO;

namespace Assetto.Common.Interfaces.Service
{
    public interface IPathService
    {
        List<PathDTO> GetPaths();
    }
}
