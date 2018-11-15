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
        public HttpResponseMessage TableInfo(string search)
        {
            if(search == "part") 
            {
                return Request.CreateResponse(HttpStatusCode.OK, Backend.Shared.InventoryTable.GetInventoryTable());
            }
            if (search == "partSystem")
            {
                return Request.CreateResponse(HttpStatusCode.OK, Backend.Systems.SelectSystem.SubSystemsTable.GetSubSystemsTable());
            }
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
