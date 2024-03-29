﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Data;
using Assetto.Common.DTO;
using Assetto.Common.Enum;
using Assetto.Common.ProcessedResult;
using Assetto.Service.Tests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assetto.Service.Tests.EventService
{
    [TestClass]
    public class EventServiceTests : UnitTestBase
    {
        [TestMethod]
        public void EventService_QualRaceOrder()
        {
            var eventService = new Service.EventService(this.ConfigServiceMock.Object);
            var dto = new ConfiguredSessionDTO();
            dto.PreviousSessionResult = new Result()
            {
                SessionType = SessionType.Qualifying,
                Players = TestData.ResultOpponentsTest1,
            };
            dto.SessionData = new SessionData()
            {
                SessionType = SessionType.Race
            };
            dto.EventData = new EventData()
            {
                Opponents = TestData.OpponentDataTest1
            };

            eventService.OrderGrid(dto);

            // Opponents
            var resultOpponentFinishedFirst = TestData.ResultOpponentsTest1.FirstOrDefault(o => o.Position == 1);
            var resultOpponentFinishedSecond = TestData.ResultOpponentsTest1.FirstOrDefault(o => o.Position == 2);
            var resultOpponentFinishedFourth = TestData.ResultOpponentsTest1.FirstOrDefault(o => o.Position ==  4);
            
            // Player finished 3rd
            var indexOfFirst =
                dto.SessionData.OrderedGrid.IndexOf(dto.SessionData.OrderedGrid.FirstOrDefault(o => o.Name == resultOpponentFinishedFirst.Name));
            var indexOfSecond =
                dto.SessionData.OrderedGrid.IndexOf(dto.SessionData.OrderedGrid.FirstOrDefault(o => o.Name == resultOpponentFinishedSecond.Name));
            var indexOfFourth =
                dto.SessionData.OrderedGrid.IndexOf(dto.SessionData.OrderedGrid.FirstOrDefault(o => o.Name == resultOpponentFinishedFourth.Name));

            Assert.IsTrue(indexOfFirst < indexOfSecond); //1,2
            Assert.IsTrue(indexOfFirst < indexOfFourth); //1,4

            Assert.IsTrue(indexOfSecond < indexOfFourth); //2,4
            Assert.AreEqual(dto.SessionData.StartingPosition, 3);


        }
    }
}
