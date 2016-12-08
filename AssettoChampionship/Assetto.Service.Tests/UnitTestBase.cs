using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Interfaces.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Assetto.Service.Tests
{
    [TestClass]
    public class UnitTestBase
    {
        public Mock<IConfigService> ConfigServiceMock { get; set; }

        public Mock<IFileService> FileServiceMock { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            this.ConfigServiceMock = new Mock<IConfigService>();
            this.ConfigServiceMock
                .Setup(m => m.GetAcX64ProcessName())
                .Returns("notepad.exe");

            this.ConfigServiceMock
                   .Setup(m => m.GetAssettoCorsaExeLoc())
                   .Returns("notepad.exe");

            this.ConfigServiceMock
                .Setup(m => m.GetPlayerName())
                .Returns("TestPlayer");

            this.FileServiceMock = new Mock<IFileService>();
            FileServiceMock
                .Setup(m => m.WriteFile(It.IsAny<string>(), It.IsAny<string>()))
                .Verifiable();
        }
    }
}
