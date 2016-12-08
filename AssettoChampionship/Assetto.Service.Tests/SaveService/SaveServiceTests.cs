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
    public class SaveServiceTests : UnitTestBase
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
            var sessionResult = new Utils.ResultService(this.ConfigServiceMock.Object).GetResultForLog(TestData.QualifyOutputLog_PlayerWithoutTime);
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
            var sessionResult = new Utils.ResultService(this.ConfigServiceMock.Object).GetResultForLog(TestData.QualifyOutputLog_PlayerWithoutTime);
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
            var originalPlayerCount = sessionResult.Players.Count;
            var newPlayerCount = originalPlayerCount - 1;
            Assert.AreEqual(savedSeason.SavedEventResults[eventId].SessionResult[sessionId].Players.Count, originalPlayerCount);

            sessionResult.Players.RemoveAt(0);

            var result = saveService.UpdateResult(savedSeason, eventId, sessionId, sessionResult);

            Assert.AreEqual(result.SeasonId, seasonId);
            Assert.AreEqual(result.SavedEventResults[eventId].EventId, eventId);
            Assert.AreEqual(result.SavedEventResults[eventId].SessionResult[sessionId].Id, sessionId);
            Assert.AreEqual(result.SavedEventResults[eventId].SessionResult[sessionId].Players.Count, newPlayerCount);
        }

        [TestMethod]
        [ExpectedException(exceptionType: typeof(Exception))]
        public void SaveService_UpdateResult_NotExist()
        {
            var seasonId = SupportedEvents.Abarth500RaceEvent1.Id;
            var eventId = SupportedEvents.Abarth500RaceEvent1.Id;
            var sessionId = SupportedSessions.Abarth500RaceEvent1Qualy.Id;


            var selectedSeries = SupportedSeries.AbarthRaceSeries;
            var selectedEvent = selectedSeries.Events.First();
            var selectedSession = selectedEvent.CareerSessions.Last();
            var sessionResult = new Utils.ResultService(this.ConfigServiceMock.Object).GetResultForLog(TestData.QualifyOutputLog_PlayerWithoutTime);
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
        public void SaveService_UpdateResult_Null()
        {
            var seasonId = SupportedEvents.Abarth500RaceEvent1.Id;
            var eventId = SupportedEvents.Abarth500RaceEvent1.Id;
            var sessionId = SupportedSessions.Abarth500RaceEvent1Qualy.Id;


            var selectedSeries = SupportedSeries.AbarthRaceSeries;
            var selectedEvent = selectedSeries.Events.First();
            var selectedSession = selectedEvent.CareerSessions.Last();
            var sessionResult = new Utils.ResultService(this.ConfigServiceMock.Object).GetResultForLog(TestData.QualifyOutputLog_PlayerWithoutTime);
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
            var sessionResult = new Utils.ResultService(this.ConfigServiceMock.Object).GetResultForLog(TestData.QualifyOutputLog_PlayerWithoutTime);
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
            Assert.AreEqual(result.SavedEventResults[eventId].SessionResult[sessionId].Players.Count, sessionResult.Players.Count);
            Assert.AreEqual(result.SavedEventResults[eventId].SessionResult[sessionId].Id, sessionId);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SaveService_InsertResult_AlreadyExist()
        {
            var seasonId = SupportedEvents.Abarth500RaceEvent1.Id;
            var eventId = SupportedEvents.Abarth500RaceEvent1.Id;
            var sessionId = SupportedSessions.Abarth500RaceEvent1Qualy.Id;


            var selectedSeries = SupportedSeries.AbarthRaceSeries;
            var selectedEvent = selectedSeries.Events.First();
            var selectedSession = selectedEvent.CareerSessions.Last();
            var sessionResult = new Utils.ResultService(this.ConfigServiceMock.Object).GetResultForLog(TestData.QualifyOutputLog_PlayerWithoutTime);
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
                                { SupportedSessions.Abarth500RaceEvent1Qualy.Id, sessionResult }
                            }

                        }
                    }
                }
            };



            var fileServiceMock = new Mock<IFileService>();

            var saveService = new Service.SaveService(fileServiceMock.Object);
            var result = saveService.InsertResult(savedSeason, eventId, sessionId, sessionResult);

        }

        [TestMethod]
        public void SaveService_InsertResult_AlreadyExistNull()
        {
            var seasonId = SupportedEvents.Abarth500RaceEvent1.Id;
            var eventId = SupportedEvents.Abarth500RaceEvent1.Id;
            var sessionId = SupportedSessions.Abarth500RaceEvent1Qualy.Id;


            var selectedSeries = SupportedSeries.AbarthRaceSeries;
            var selectedEvent = selectedSeries.Events.First();
            var selectedSession = selectedEvent.CareerSessions.Last();
            var sessionResult = new Utils.ResultService(this.ConfigServiceMock.Object).GetResultForLog(TestData.QualifyOutputLog_PlayerWithoutTime);
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
                                { SupportedSessions.Abarth500RaceEvent1Qualy.Id, null }
                            }

                        }
                    }
                }
            };



            var fileServiceMock = new Mock<IFileService>();

            var saveService = new Service.SaveService(fileServiceMock.Object);
            var result = saveService.InsertResult(savedSeason, eventId, sessionId, sessionResult);


            Assert.AreEqual(result.SeasonId, seasonId);
            Assert.AreEqual(result.SavedEventResults[eventId].SessionResult[sessionId].Players.Count, sessionResult.Players.Count);
            Assert.AreEqual(result.SavedEventResults[eventId].SessionResult[sessionId].Id, sessionId);

        }

        [TestMethod]
        public void SavedSeasonContainsSession_Contains()
        {
            var seasonId = SupportedEvents.Abarth500RaceEvent1.Id;
            var eventId = SupportedEvents.Abarth500RaceEvent1.Id;
            var sessionId = SupportedSessions.Abarth500RaceEvent1Qualy.Id;


            var selectedSeries = SupportedSeries.AbarthRaceSeries;
            var selectedEvent = selectedSeries.Events.First();
            var selectedSession = selectedEvent.CareerSessions.Last();
            var sessionResult = new Utils.ResultService(this.ConfigServiceMock.Object).GetResultForLog(TestData.QualifyOutputLog_PlayerWithoutTime);

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
                                { SupportedSessions.Abarth500RaceEvent1Qualy.Id, sessionResult }
                            }

                        }
                    }
                }
            };

            var fileServiceMock = new Mock<IFileService>();

            var saveService = new Service.SaveService(fileServiceMock.Object);
            Assert.IsTrue(saveService.SavedSeasonContainsSession(savedSeason, eventId, sessionId));

        }

        [TestMethod]
        public void SavedSeasonContainsSession_EventIdGivenInsteadOfSessionId()
        {
            var seasonId = SupportedEvents.Abarth500RaceEvent1.Id;
            var eventId = SupportedEvents.Abarth500RaceEvent1.Id;
            var sessionId = SupportedEvents.Abarth500RaceEvent1.Id; ;


            var selectedSeries = SupportedSeries.AbarthRaceSeries;
            var selectedEvent = selectedSeries.Events.First();
            var selectedSession = selectedEvent.CareerSessions.Last();
            var sessionResult = new Utils.ResultService(this.ConfigServiceMock.Object).GetResultForLog(TestData.QualifyOutputLog_PlayerWithoutTime);

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
                                { SupportedSessions.Abarth500RaceEvent1Qualy.Id, sessionResult }
                            }

                        }
                    }
                }
            };

            var fileServiceMock = new Mock<IFileService>();

            var saveService = new Service.SaveService(fileServiceMock.Object);
            Assert.IsFalse(saveService.SavedSeasonContainsSession(savedSeason, eventId, sessionId));

        }

        [TestMethod]
        public void SavedSeasonContainsSession_SessionIdMissing()
        {
            var seasonId = SupportedEvents.Abarth500RaceEvent1.Id;
            var eventId = SupportedEvents.Abarth500RaceEvent1.Id;
            var sessionId = Guid.NewGuid(); // New random guid


            var selectedSeries = SupportedSeries.AbarthRaceSeries;
            var selectedEvent = selectedSeries.Events.First();
            var selectedSession = selectedEvent.CareerSessions.Last();
            var sessionResult = new Utils.ResultService(this.ConfigServiceMock.Object).GetResultForLog(TestData.QualifyOutputLog_PlayerWithoutTime);

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
                                { SupportedSessions.Abarth500RaceEvent1Qualy.Id, sessionResult }
                            }

                        }
                    }
                }
            };

            var fileServiceMock = new Mock<IFileService>();

            var saveService = new Service.SaveService(fileServiceMock.Object);
            Assert.IsFalse(saveService.SavedSeasonContainsSession(savedSeason, eventId, sessionId));

        }

        [TestMethod]
        public void SavedSeasonContainsSession_EventIdMissing()
        {
            var seasonId = SupportedEvents.Abarth500RaceEvent1.Id;
            var eventId = Guid.NewGuid(); // New random guid
            var sessionId = SupportedSessions.Abarth500RaceEvent1Qualy.Id;


            var selectedSeries = SupportedSeries.AbarthRaceSeries;
            var selectedEvent = selectedSeries.Events.First();
            var selectedSession = selectedEvent.CareerSessions.Last();
            var sessionResult = new Utils.ResultService(this.ConfigServiceMock.Object).GetResultForLog(TestData.QualifyOutputLog_PlayerWithoutTime);

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
                                { SupportedSessions.Abarth500RaceEvent1Qualy.Id, sessionResult }
                            }

                        }
                    }
                }
            };

            var fileServiceMock = new Mock<IFileService>();

            var saveService = new Service.SaveService(fileServiceMock.Object);
            Assert.IsFalse(saveService.SavedSeasonContainsSession(savedSeason, eventId, sessionId));

        }


    }
}
