using Assetto.Common.Data;
using Assetto.Common.Interfaces.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace AssettoChampionship.Web.Controllers
{
    [RoutePrefix("series/")]
    public class SeriesController : ApiController
    {
        public ISeriesManager SeriesManager { get; set; }

        public SeriesController(ISeriesManager seriesManager)
        {
            this.SeriesManager = seriesManager;
        }
        // GET api/values 
        [HttpGet]
        [Route("GetSeries")]
        public JsonResult<IEnumerable<SeriesData>> GetSeries()
        {
            return Json(this.SeriesManager.GetAvailableSeries());
        }
    }
}
