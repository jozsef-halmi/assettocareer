using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Objectives;
using Assetto.Service.Tests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assetto.Service.Tests.ResultService
{
    [TestClass]
    public class ResultServiceTests
    {
        [TestMethod]
        public void ProcessResultTest_1()
        {
            var resultService = new Utils.ResultService();
            var result = resultService.GetResult(TestData.QualifyOutputLog_PlayerWithoutTime);

            // Evaluate TOP Finish
            var finishPodiumObjective = new FinishTopNSessionObjective()
            {
                N = 3
            };

            var finishPodium = finishPodiumObjective.Evaluate(result);
            Assert.IsFalse(finishPodium);
        }

        [TestMethod]
        public void ProcessResultTest_2()
        {
            var resultService = new Utils.ResultService();
            var result = resultService.GetResult(TestData.QualifyOutputLog_PlayerWithoutTime);

            // Evaluate TOP Finish
            var finishFirst15 = new FinishTopNSessionObjective()
            {
                N = 15
            };

            var finishedFirst15 = finishFirst15.Evaluate(result);
            Assert.IsTrue(finishedFirst15);

        }
    }
}
