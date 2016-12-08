using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Enum;
using Assetto.Common.Interfaces.Service;
using Assetto.Common.ProcessedResult;
using Assetto.Common.Utils;
using Assetto.Service.Tests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Assetto.Service.Tests.EventManager
{
    [TestClass]
    public class EventManagerTests : UnitTestBase
    {
        [TestMethod]
        [Ignore]
        public void EventManager_1()
        {
            //var seriesServiceMock = new Mock<ISeriesService>();
            //var processServiceMock = new Mock<IProcessService>();
            //var saveService = new Mock<ISaveService>();
            ////var eventService
            //// SeriesService

            //// ProcessService
            //processServiceMock
            //    .Setup(m => m.StartProcess(It.IsAny<string>()))
            //    .Verifiable();

            //processServiceMock
            //    .Setup(m => m.MonitorProcess(It.IsAny<string>(),
            //        It.IsAny<ProcessInfo.StartedEventHandler>(),
            //        It.IsAny<ProcessInfo.TerminatedEventHandler>()))
            //    .Verifiable();

            //// SaveService
            //saveService
            //    .Setup(m => m.LoadResult(It.IsAny<Guid>(),
            //        It.IsAny<Guid>(),
            //        It.IsAny<Guid>()))
            //    .Returns(new Result()
            //    {
            //        SessionType = SessionType.Qualifying,
            //        QualificationResult = TestData.ResultOpponents
            //    });


            //var eventManager = new Manager.EventManager(
            //    this.FileServiceMock.Object,
            //    seriesServiceMock.Object,

            //    );


        }
    }
}
