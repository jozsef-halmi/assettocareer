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
        public void ProcessResultTest()
        {
            var resultService = new Utils.ResultService();
            var result = resultService.GetResult(TestData.QualifyOutputLog_PlayerWithoutTime);

            // Evaluate TOP Finish
            var finishNObjective = new FinishTopNSessionObjective()
            {
                N = 3
            };

            finishNObjective.Evaluate(result);
        }
    }
}
