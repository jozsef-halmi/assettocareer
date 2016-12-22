//using Assetto.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Assetto.Backend.Controllers
{
    [RoutePrefix("series")]
    public class SeriesController : ApiController
    {
        //[HttpGet]
        //[Route("GetSeries")]
        //public IHttpActionResult GetSeries()
        //{
        //    return Json(SupportedSeries.getv);
        //}

        //[HttpGet]
        //[Route("GetVideo/{seriesId}")]
        //public IHttpActionResult GetVideo(string seriesId)
        //{
        //    var selectedSeriesVideourl = SupportedSeries.AllSeries.FirstOrDefault(s => s.Id == seriesId)?.VideoUrl;
        //    return File(Server.MapPath("~/Videos/a2.mp4"), "video/mp4", "my.mp4");
        //}
    }
}