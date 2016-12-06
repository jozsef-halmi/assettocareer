using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Interfaces.Service;
using Assetto.Common.ProcessedResult;
using Assetto.Common.SaveGames;
using Assetto.Data;
using Assetto.Service.Tests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace Assetto.Service.Tests.SaveService
{
    [TestClass]
    public class SaveServiceTests
    {
        [TestMethod]
        public void SaveService_LoadResult()
        {
            var seasonId = SupportedEvents.Abarth500RaceEvent1.Id;
            var eventId = SupportedEvents.Abarth500RaceEvent1.Id;
            var sessionId = SupportedSessions.Abarth500RaceEvent1Qualy.Id;


            var selectedSeries = SupportedSeries.AbarthRaceSeries;
            var selectedEvent = selectedSeries.Events.First();
            var selectedSession = selectedEvent.CareerSessions.Last();
            var sessionResult = new Utils.ResultService().GetResult(TestData.QualifyOutputLog_PlayerWithoutTime);
            sessionResult.Id = sessionId;
          

            var savedSeason = new SavedSeason()
            {
                SeasonId = SupportedEvents.Abarth500RaceEvent1.Id,
                SavedEventResults = new Dictionary<Guid, SavedEventResult>()
                {
                    {
                        SupportedEvents.Abarth500RaceEvent1.Id,
                        new SavedEventResult()
                        {
                            EventId = SupportedEvents.Abarth500RaceEvent1.Id,
                            SessionResult = new Dictionary<Guid, Result>()
                            {
                                { SupportedSessions.Abarth500RaceEvent1Qualy.Id,
                                  sessionResult
                                }
                            }
                            
                        }
                    }
                }
            };

            var fileServiceMock = new Mock<IFileService>();
            fileServiceMock
                .Setup(fs => fs.ReadFile(It.IsAny<string>()))
                .Returns(JsonConvert.SerializeObject(savedSeason));

            var saveService = new Service.SaveService(fileServiceMock.Object);
            var result = saveService.LoadResult(seasonId, eventId, sessionId);

            Assert.AreEqual(result.Id, sessionId);


        }

        [TestMethod]
        public void SaveService_UpdateResult_Intended()
        {
            var seasonId = SupportedEvents.Abarth500RaceEvent1.Id;
            var eventId = SupportedEvents.Abarth500RaceEvent1.Id;
            var sessionId = SupportedSessions.Abarth500RaceEvent1Qualy.Id;


            var selectedSeries = SupportedSeries.AbarthRaceSeries;
            var selectedEvent = selectedSeries.Events.First();
            var selectedSession = selectedEvent.CareerSessions.Last();
            var sessionResult = new Utils.ResultService().GetResult(TestData.QualifyOutputLog_PlayerWithoutTime);
            sessionResult.Id = sessionId;


            var savedSeason = new SavedSeason()
            {
                SeasonId = SupportedEvents.Abarth500RaceEvent1.Id,
                SavedEventResults = new Dictionary<Guid, SavedEventResult>()
                {
                    {
                        SupportedEvents.Abarth500RaceEvent1.Id,
                        new SavedEventResult()
                        {
                            EventId = SupportedEvents.Abarth500RaceEvent1.Id,
                            SessionResult = new Dictionary<Guid, Result>()
                            {
                                { SupportedSessions.Abarth500RaceEvent1Qualy.Id,
                                  sessionResult
                                }
                            }

                        }
                    }
                }
            };



            var fileServiceMock = new Mock<IFileService>();

            var saveService = new Service.SaveService(fileServiceMock.Object);
            var originalPlayerCount = sessionResult.QualificationResult.Count;
            var newPlayerCount = originalPlayerCount - 1;
            Assert.AreEqual(savedSeason.SavedEventResults[eventId].SessionResult[sessionId].QualificationResult.Count, originalPlayerCount);

            sessionResult.QualificationResult.RemoveAt(0);

            var result = saveService.UpdateResult(savedSeason, eventId, sessionId, sessionResult);

            Assert.AreEqual(result.SeasonId, seasonId);
            Assert.AreEqual(result.SavedEventResults[eventId].EventId, eventId);
            Assert.AreEqual(result.SavedEventResults[eventId].SessionResult[sessionId].Id, sessionId);
            Assert.AreEqual(result.SavedEventResults[eventId].SessionResult[sessionId].QualificationResult.Count, newPlayerCount);
        }

        [TestMethod]
        [ExpectedException(exceptionType: typeof(KeyNotFoundException))]
        public void SaveService_UpdateResult_NotExist()
        {
            var seasonId = SupportedEvents.Abarth500RaceEvent1.Id;
            var eventId = SupportedEvents.Abarth500RaceEvent1.Id;
            var sessionId = SupportedSessions.Abarth500RaceEvent1Qualy.Id;


            var selectedSeries = SupportedSeries.AbarthRaceSeries;
            var selectedEvent = selectedSeries.Events.First();
            var selectedSession = selectedEvent.CareerSessions.Last();
            var sessionResult = new Utils.ResultService().GetResult(TestData.QualifyOutputLog_PlayerWithoutTime);
            sessionResult.Id = sessionId;


            var savedSeason = new SavedSeason()
            {
                SeasonId = SupportedEvents.Abarth500RaceEvent1.Id,
                SavedEventResults = new Dictionary<Guid, SavedEventResult>()
                {
                    {
                        SupportedEvents.Abarth500RaceEvent1.Id,
                        new SavedEventResult()
                        {
                            EventId = SupportedEvents.Abarth500RaceEvent1.Id,
                            SessionResult = new Dictionary<Guid, Result>()
                            {
                                
                            }

                        }
                    }
                }
            };

            var fileServiceMock = new Mock<IFileService>();
            var saveService = new Service.SaveService(fileServiceMock.Object);
            var result = saveService.UpdateResult(savedSeason, eventId, sessionId, sessionResult);
        }

        [TestMethod]
        [ExpectedException(exceptionType: typeof(Exception))]
        public void SaveService_UpdateResult_Null()
        {
            var seasonId = SupportedEvents.Abarth500RaceEvent1.Id;
            var eventId = SupportedEvents.Abarth500RaceEvent1.Id;
            var sessionId = SupportedSessions.Abarth500RaceEvent1Qualy.Id;


            var selectedSeries = SupportedSeries.AbarthRaceSeries;
            var selectedEvent = selectedSeries.Events.First();
            var selectedSession = selectedEvent.CareerSessions.Last();
            var sessionResult = new Utils.ResultService().GetResult(TestData.QualifyOutputLog_PlayerWithoutTime);
            sessionResult.Id = sessionId;


            var savedSeason = new SavedSeason()
            {
                SeasonId = SupportedEvents.Abarth500RaceEvent1.Id,
                SavedEventResults = new Dictionary<Guid, SavedEventResult>()
                {
                    {
                        SupportedEvents.Abarth500RaceEvent1.Id,
                        new SavedEventResult()
                        {
                            EventId = SupportedEvents.Abarth500RaceEvent1.Id,
                            SessionResult = new Dictionary<Guid, Result>()
                            {
                                {sessionId, null}
                            }

                        }
                    }
                }
            };

            var fileServiceMock = new Mock<IFileService>();
            var saveService = new Service.SaveService(fileServiceMock.Object);
            var result = saveService.UpdateResult(savedSeason, eventId, sessionId, sessionResult);
        }



        [TestMethod]
        public void SaveService_InsertResult_Intended()
        {
            var seasonId = SupportedEvents.Abarth500RaceEvent1.Id;
            var eventId = SupportedEvents.Abarth500RaceEvent1.Id;
            var sessionId = SupportedSessions.Abarth500RaceEvent1Qualy.Id;


            var selectedSeries = SupportedSeries.AbarthRaceSeries;
            var selectedEvent = selectedSeries.Events.First();
            var selectedSession = selectedEvent.CareerSessions.Last();
            var sessionResult = new Utils.ResultService().GetResult(TestData.QualifyOutputLog_PlayerWithoutTime);
            sessionResult.Id = sessionId;

            // This should be inserted:
            //{ SupportedSessions.Abarth500RaceEvent1Qualy.Id, sessionResult }

            var savedSeason = new SavedSeason()
            {
                SeasonId = SupportedEvents.Abarth500RaceEvent1.Id,
                SavedEventResults = new Dictionary<Guid, SavedEventResult>()
                {
                    {
                        SupportedEvents.Abarth500RaceEvent1.Id,
                        new SavedEventResult()
                        {
                            EventId = SupportedEvents.Abarth500RaceEvent1.Id,
                            SessionResult = new Dictionary<Guid, Result>()
                            {
                                
                            }

                        }
                    }
                }
            };



            var fileServiceMock = new Mock<IFileService>();

            var saveService = new Service.SaveService(fileServiceMock.Object);
            var result = saveService.InsertResult(savedSeason, eventId, sessionId, sessionResult);

            Assert.AreEqual(result.SeasonId, seasonId);
            Assert.AreEqual(result.SavedEventResults[eventId].SessionResult[sessionId].QualificationResult.Count, sessionResult.QualificationResult.Count);
            Assert.AreEqual(result.SavedEventResults[eventId].SessionResult[sessionId].Id, sessionId);

        }

    }
}
