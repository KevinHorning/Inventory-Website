using System.Net;
using System.Net.Http;
using System.Web.Http;
using Atlas2.Models;

namespace Atlas2.Controllers
{
    [RoutePrefix("api/Equipment")]
    public class EquipmentController : ApiController
    {
        [HttpGet]
        [Route("table")]
        public HttpResponseMessage TableInfo()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new TableResponse<Equipment> {});
        }
    }
}
