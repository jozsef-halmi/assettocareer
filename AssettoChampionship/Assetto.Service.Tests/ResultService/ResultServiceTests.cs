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
        public void ProcessResult__FinishTopNEvaluatorTest1()
        {
            var resultService = new Utils.ResultService();
            var result = resultService.GetResultForLog(TestData.QualifyOutputLog_PlayerWithoutTime);

            // Evaluate TOP Finish
            var finishPodiumObjective = new FinishTopNSessionObjective()
            {
                N = 3
            };

            var finishPodium = finishPodiumObjective.Evaluate(result);
            Assert.IsFalse(finishPodium);
        }

        [TestMethod]
        public void ProcessResult_FinishTopNEvaluatorTest2()
        {
            var resultService = new Utils.ResultService();
            var result = resultService.GetResultForLog(TestData.QualifyOutputLog_PlayerWithoutTime);

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
        public void ProcessResult_FinishBeforeEvaluatorTest_NameNotPresent()
        {
            var resultService = new Utils.ResultService();
            var result = resultService.GetResultForLog(TestData.QualifyOutputLog_PlayerWithoutTime);

            // Evaluate TOP Finish
            var finishBefore = new FinishBeforeObjective()
            {
                Name = "SomeName"
            };

            finishBefore.Evaluate(result);

        }

        [TestMethod]
        public void ProcessResult_FinishBeforeEvaluatorTest_ObjectiveFalse()
        {
            var resultService = new Utils.ResultService();
            var result = resultService.GetResultForLog(TestData.QualifyOutputLog_PlayerWithoutTime);

            // Evaluate TOP Finish
            var finishBefore = new FinishBeforeObjective()
            {
                Name = "Kendal Buckley"
            };

            var isSuccess =  finishBefore.Evaluate(result);
            Assert.IsFalse(isSuccess);

        }

        [TestMethod]
        public void ProcessResult_FinishBeforeEvaluatorTest_ObjectiveTrue()
        {
            var resultService = new Utils.ResultService();
            var result = resultService.GetResultForLog(TestData.QualifyOutputLog_PlayerWithoutTime);

            // Evaluate TOP Finish
            var finishBefore = new FinishBeforeObjective()
            {
                Name = "Kendal Buckley"
            };

            var isSuccess = finishBefore.Evaluate(result);
            Assert.IsFalse(isSuccess);

        }


        [TestMethod]
        public void ProcessResult_Race1_FinishTop()
        {
            var resultService = new Utils.ResultService();
            var result = resultService.GetResultForLog(TestData.RaceOutputLog_Player2nd);

            // Evaluate TOP Finish
            var finishFirst15 = new FinishTopNSessionObjective() { N = 15 };
            var finishFirst10 = new FinishTopNSessionObjective() { N = 10 };
            var finishFirst5 = new FinishTopNSessionObjective() { N = 5 };
            var finishFirst4 = new FinishTopNSessionObjective() { N = 4 };
            var finishFirst3 = new FinishTopNSessionObjective() { N = 3 };
            var finishFirst2 = new FinishTopNSessionObjective() { N = 2 };
            var finishFirst1 = new FinishTopNSessionObjective() { N = 1 };


            Assert.IsTrue(finishFirst15.Evaluate(result));
            Assert.IsTrue(finishFirst10.Evaluate(result));
            Assert.IsTrue(finishFirst5.Evaluate(result));
            Assert.IsTrue(finishFirst4.Evaluate(result));
            Assert.IsTrue(finishFirst3.Evaluate(result));
            Assert.IsTrue(finishFirst2.Evaluate(result));

            // Should be false
            Assert.IsFalse(finishFirst1.Evaluate(result));

        }

        [TestMethod]
        public void ProcessResult_Race1_FinishBefore()
        {
            var resultService = new Utils.ResultService();
            var result = resultService.GetResultForLog(TestData.RaceOutputLog_Player2nd);

            // Evaluate TOP Finish
            var finishBeforeJazmineShouldBeFalse = new FinishBeforeObjective() { Name = "Jazmine Hermanson" };
            var finishBeforeKendalShouldBeTrue = new FinishBeforeObjective() { Name = "Kendal Buckley" };
            var finishBeforeErlendShouldBeTrue = new FinishBeforeObjective() { Name = "Erlend Braband" };
            var finishBeforeKurtisShouldBeTrue = new FinishBeforeObjective() { Name = "Kurtis Nadeau" };
            var finishBeforeDarellShouldBeTrue = new FinishBeforeObjective() { Name = "Darell Hoyt" };

            Assert.IsFalse(finishBeforeJazmineShouldBeFalse.Evaluate(result));
            Assert.IsTrue(finishBeforeKendalShouldBeTrue.Evaluate(result));
            Assert.IsTrue(finishBeforeErlendShouldBeTrue.Evaluate(result));
            Assert.IsTrue(finishBeforeKurtisShouldBeTrue.Evaluate(result));
            Assert.IsTrue(finishBeforeDarellShouldBeTrue.Evaluate(result));
        }

    }
}
