using System.Net;
using System.Net.Http;
using System.Web.Http;
using Atlas2.Controllers;

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
        
        //[HttpPost]
        //[Route("searchRequest")]
        //public HttpRequestMessage SearchInfo(SearchFilter model)
        //{
        //    return Request.CreateResponseResponse(HttpStatusCode.OK, DatabaseTableResultMethod("parts", model));
        //}
    }
}
