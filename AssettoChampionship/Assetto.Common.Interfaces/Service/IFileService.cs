using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Common.Interfaces.Service
{
    public interface IFileService
    {
        string ReadFile(string path);
        void WriteFile(string path, string contents);
    }
}
