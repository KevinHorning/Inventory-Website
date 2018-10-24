using System.Net;
using System.Net.Http;
using System.Web.Http;
using Atlas2.Models;

namespace Atlas2.Controllers
{
    [RoutePrefix("api/Inventory")]
    public class InventoryController : ApiController
    {
        [HttpGet]
        [Route("table")]
        public HttpResponseMessage TableInfo() 
        {
            return Request.CreateResponse(HttpStatusCode.OK, new TableResponse<Part>{});
        }
    }
}
