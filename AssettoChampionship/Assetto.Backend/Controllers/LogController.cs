using Assetto.Backend.Data;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;

namespace Assetto.Backend.Controllers
{
    [RoutePrefix("log")]
    public class LogController : ApiController
    {
        private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string LOG_FILE = "logs.txt";

        //private class Log
        //{
        //    public string Text { get; set; }
        //}

        // GET: Log
        [HttpGet]
        [Route("InsertLog/{machineName}/{severity}/{message}")]
        public IHttpActionResult InsertLog(string machineName, int severity, string message)
        {
            using (var db = new AssettoDBEntities3())
            {
                //var nextId = db.LogEntries.OrderByDescending(le => le.Id).First()?.Id + 1;
                db.LogEntries.Add(new LogEntries() {
                    //Id = nextId??0,
                    MachineName = machineName,
                    Message = message,
                    Severity = severity
                });
                db.SaveChanges();
                return Json(message);
            }
        }

        [HttpGet]
        [Route("GetLogs")]
        public IHttpActionResult GetLogs()
        {
            using (var db = new AssettoDBEntities3())
            {
                return Json(db.LogEntries.ToList());
            }
        }
        [HttpGet]
        [Route("GetLogsForMachine/{machineName}")]
        public IHttpActionResult GetLogs(string machineName)
        {
            using (var db = new AssettoDBEntities3())
            {
                return Json(db.LogEntries.Where(le => le.MachineName == machineName).ToList());
            }
        }

        [HttpGet]
        [Route("RemoveLogs")]
        public IHttpActionResult RemoveLogs(string machineName)
        {
            using (var db = new AssettoDBEntities3())
            {
                db.LogEntries.RemoveRange(db.LogEntries);
                db.SaveChanges();
                return Json(true);
            }
        }
    }
}