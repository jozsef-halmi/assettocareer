using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Interfaces.Service;
using Assetto.Common.ProcessedResult;

namespace Assetto.Service
{
    public class SaveService : ISaveService
    {
        public const string RESULT_DIR = "Data";
        public const string RESULT_FILE_NAME = "Data.dat";

        public IFileService FileService { get; set; }

        public SaveService(IFileService fileService)
        {
            this.FileService = fileService;
        }

        public bool SaveResult(Guid seasonId, Guid eventId, Guid sessionId, Result result)
        {
            Result previousResults = null;
            if (!CreateResultFileIfNotExist(seasonId))
            {
                // File already existed   
            }
        }

        public Result LoadResult(Guid seasonId, Guid eventId, Guid sessionId)
        {
            throw new NotImplementedException();
        }


        private Result LoadResultFile(Guid seasonId)
        {
            
        }


        private bool CreateResultFileIfNotExist(Guid seasonId)
        {
            // Create result dir if not exists
            this.FileService.CreateDirIfNotExist(RESULT_DIR);

            var filePath = RESULT_DIR
                 + Path.DirectorySeparatorChar + seasonId;

            // Create season result dir if not exists
            this.FileService.CreateDirIfNotExist(filePath);

            return this.FileService.CreateResultFileIfNotExist(filePath);
        }
    }
}
