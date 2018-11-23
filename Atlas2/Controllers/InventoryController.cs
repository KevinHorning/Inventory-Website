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
        public HttpResponseMessage TableInfo(string search)
        {
            if (search == "part")
            {
                var a = Backend.Shared.InventoryTable.GetInventoryTable();
                object[] t = new object[a.partsData.Length + a.systemsData.Length];
                for (int i = 0; i < t.Length; i++) {
                    if (i < a.partsData.Length)
                    {
                        t[i] = new Backend.Parts.Part
                        {
                            name = a.partsData[i].name,
                            SKU = a.partsData[i].SKU,
                            count = a.partsData[i].count,
                            itemType = a.partsData[i].itemType
                        };
                    }
                    else
                        t[i] = new Backend.Systems.System
                        {
                            name = a.systemsData[i - a.partsData.Length].name,
                            SKU = a.systemsData[i - a.partsData.Length].SKU,
                            count = a.systemsData[i - a.partsData.Length].count,
                            itemType = a.systemsData[i - a.partsData.Length].itemType
                        };
                }

                var b = new TableInfo
                {
                    Headers = new []{"name", "SKU", "count", "itemType"},
                    Data = t
                };
                return Request.CreateResponse(HttpStatusCode.OK, b);
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
