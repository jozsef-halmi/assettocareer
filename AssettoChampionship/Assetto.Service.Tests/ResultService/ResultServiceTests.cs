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
        public void ProcessResultTest__FinishTopNEvaluatorTest1()
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
        public void ProcessResultTest_FinishTopNEvaluatorTest2()
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessResultTest_FinishBeforeEvaluatorTest_NameNotPresent()
        {
            var resultService = new Utils.ResultService();
            var result = resultService.GetResult(TestData.QualifyOutputLog_PlayerWithoutTime);

            // Evaluate TOP Finish
            var finishBefore = new FinishBeforeObjective()
            {
                Name = "SomeName"
            };

            finishBefore.Evaluate(result);

        }

        [TestMethod]
        public void ProcessResultTest_FinishBeforeEvaluatorTest_ObjectiveFalse()
        {
            var resultService = new Utils.ResultService();
            var result = resultService.GetResult(TestData.QualifyOutputLog_PlayerWithoutTime);

            // Evaluate TOP Finish
            var finishBefore = new FinishBeforeObjective()
            {
                Name = "Kendal Buckley"
            };

            var isSuccess =  finishBefore.Evaluate(result);
            Assert.IsFalse(isSuccess);

        }

        [TestMethod]
        public void ProcessResultTest_FinishBeforeEvaluatorTest_ObjectiveTrue()
        {
            var resultService = new Utils.ResultService();
            var result = resultService.GetResult(TestData.QualifyOutputLog_PlayerWithoutTime);

            // Evaluate TOP Finish
            var finishBefore = new FinishBeforeObjective()
            {
                Name = "Kendal Buckley"
            };

            var isSuccess = finishBefore.Evaluate(result);
            Assert.IsFalse(isSuccess);
            Assert.IsTrue(false); // TODO: Implement

        }
    }
}
