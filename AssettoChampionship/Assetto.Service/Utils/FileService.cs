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

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public bool DirExists(string path)
        {
            return Directory.Exists(path);
        }

        public void CreateDirIfNotExist(string dirPath)
        {
            System.IO.Directory.CreateDirectory(dirPath);

        }

        public bool CreateResultFileIfNotExist(string filePath, string contents)
        {
            if (!File.Exists(filePath))
            {
                //File.Create(filePath,);
                this.WriteFile(filePath, contents);
                return true;
            }
            return false;
        }
    }
}
