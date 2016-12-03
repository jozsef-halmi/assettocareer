using Assetto.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assetto.Service
{
    public class FileService : IFileService
    {
        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        public void WriteFile(string path, string contents)
        {
            // It overwrites the file.
            File.WriteAllText(path, contents);
        }
    }
}
