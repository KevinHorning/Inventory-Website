using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Atlas2.Controllers
{
    [RoutePrefix("api/Equipment")]
    public class EquipmentController : ApiController
    {
        [HttpGet]
        [Route("table")]
        public HttpResponseMessage TableInfo(string search)
        {
            var dbManager = new Backend.Managers.DatabaseManager();
            return Request.CreateResponse(HttpStatusCode.OK, dbManager.GetEquipmentTable());
        }
    }
}
