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
            if (search == "part")
            {
                return Request.CreateResponse(HttpStatusCode.OK, Backend.Shared.InventoryTable.GetInventoryTable());
            }
            else if (search == "partSystem")
            {
                return Request.CreateResponse(HttpStatusCode.OK, Backend.Systems.MiniSystem.SubSystemsTable.GetSubSystemsTable());
            }
            else if (search == "systemEdit")
            {
                return Request.CreateResponse(HttpStatusCode.OK, Backend.Parts.MiniPart.MiniPartsTable.GetMiniPartsTable());
            }
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [Route("addCount")]
        public HttpResponseMessage addCount(int partID, int count) 
        {
            return Request.CreateResponse(HttpStatusCode.OK/*,BackendMethod(partID, count) */);
        }

        [HttpPost]
        [Route("removeCount")]
        public HttpResponseMessage removeCount(int partID, int count)
        {
            return Request.CreateResponse(HttpStatusCode.OK/*,BackendMethod(partID, count) */);
        }


    }
}
