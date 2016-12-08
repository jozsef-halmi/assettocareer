using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.DTO;
using Assetto.Common.Enum;
using Assetto.Common.Interfaces.Service;
using Assetto.Common.ProcessedResult;
using Assetto.Common.SaveGames;
using Assetto.Common.Utils;
using Assetto.Data;
using Assetto.Service.Tests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Assetto.Service.Tests.EventManager
{
    [TestClass]
    public class EventManagerTests : UnitTestBase
    {
        [TestMethod]
        public void EventManager_1()
        {
            var seriesServiceMock = new Mock<ISeriesService>();
            var processServiceMock = new Mock<IProcessService>();
            var saveService = new Mock<ISaveService>();
            var resultServiceMock = new Mock<IResultService>();
            var eventServiceMock = new Mock<IEventService>();


            // FileService
            FileServiceMock
             .Setup(m => m.ReadFile(It.IsAny<string>()))
             .Returns(string.Empty);


            // SeriesService

            // ProcessService
            processServiceMock
                .Setup(m => m.StartProcess(It.IsAny<string>()))
                .Verifiable();

            processServiceMock
                .Setup(m => m.MonitorProcess(It.IsAny<string>(),
                    It.IsAny<ProcessInfo.StartedEventHandler>(),
                    It.IsAny<ProcessInfo.TerminatedEventHandler>()))
                .Verifiable();

            // SaveService
            saveService
                .Setup(m => m.LoadResult(It.IsAny<Guid>(),
                    It.IsAny<Guid>(),
                    It.IsAny<Guid>()))
                .Returns(new Result()
                {
                    SessionType = SessionType.Qualifying,
                    QualificationResult = TestData.ResultOpponentsTest1
                });

            saveService
                .Setup(m => m.SaveResult(
                    It.IsAny<Guid>(),
                    It.IsAny<Guid>(),
                    It.IsAny<Guid>(),
                    It.IsAny<Result>()
                ))
                .Returns(new SavedSeason());

            // ResultService
            resultServiceMock
                .Setup(m => m.GetResultForLog(It.IsAny<string>()))
                .Returns(new Result());

            // EventService
            eventServiceMock.Setup(m => m.OrderGrid(It.IsAny<ConfiguredSessionDTO>())).Verifiable();

            var eventManager = new Manager.EventManager(
                this.FileServiceMock.Object,
                seriesServiceMock.Object,
                processServiceMock.Object,
                resultServiceMock.Object,
                saveService.Object,
                this.ConfigServiceMock.Object,
                eventServiceMock.Object
                );

        


        eventManager.StartEvent(SupportedSeries.AbarthRaceSeries,
                SupportedEvents.Abarth500RaceEvent1,
                SupportedSessions.Abarth500RaceEvent1Race1);
        }
    }
}
