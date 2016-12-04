using Assetto.Common.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Interfaces.Service
{
    public interface IResultService
    {
        EventResult GetResult(string contents);
    }
}
