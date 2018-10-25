using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Atlas2.Controllers
{
    [RoutePrefix("api/Inventory")]
    public class InventoryController : ApiController
    {
        [HttpGet]
        [Route("table")]
        public HttpResponseMessage TableInfo() 
        {
            return Request.CreateResponse(HttpStatusCode.OK, Backend.Shared.TableData.getTableData("parts"));
        }
    }
}
