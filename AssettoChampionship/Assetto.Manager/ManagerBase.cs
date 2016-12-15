using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Interfaces.Service;

namespace Assetto.Manager
{
    public class ManagerBase
    {
        public ILogService LogService { get; set; }
        public IFileService FileService { get; set; }
        public IConfigService ConfigService { get; set; }

        public ManagerBase(ILogService logService
            , IFileService fileService
            , IConfigService configService)
        {
            this.LogService = logService;
            this.FileService = fileService;
            this.ConfigService = configService;
        }
    }
}
