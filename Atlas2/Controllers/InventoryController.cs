using System.Net;
using System.Net.Http;
using System.Web.Http;
using Atlas2.Models;

namespace Atlas2.Controllers
{
    [RoutePrefix("api/Inventory")]
    public class InventoryController : ApiController
    {
        private static Backend.Shared.InventoryTable currentTable;

        [HttpGet]
        [Route("table")]
        public HttpResponseMessage TableInfo(string search)
        {
            if (search == "part")
            {
                currentTable = Backend.Shared.InventoryTable.GetInventoryTable();
                object[] t = new object[currentTable.partsData.Length + currentTable.systemsData.Length];
                for (int i = 0; i < t.Length; i++) {
                    if (i < currentTable.partsData.Length)
                    {
                        t[i] = new Backend.Parts.Part
                        {
                            name = currentTable.partsData[i].name,
                            SKU = currentTable.partsData[i].SKU,
                            count = currentTable.partsData[i].count,
                            itemType = currentTable.partsData[i].itemType
                        };
                    }
                    else
                        t[i] = new Backend.Systems.System
                        {
                            name = currentTable.systemsData[i - currentTable.partsData.Length].name,
                            SKU = currentTable.systemsData[i - currentTable.partsData.Length].SKU,
                            count = currentTable.systemsData[i - currentTable.partsData.Length].count,
                            itemType = currentTable.systemsData[i - currentTable.partsData.Length].itemType
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

        [HttpGet]
        [Route("modalData")]
        public HttpResponseMessage modalData(string sku)
        {
            for (int i = 0; i < currentTable.partsData.Length + currentTable.systemsData.Length; i++) 
            {
                if(i < currentTable.partsData.Length) 
                {
                    if (sku == currentTable.partsData[i].SKU)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, currentTable.partsData[i]);
                    }
                } 
                else 
                {
                    if (sku == currentTable.systemsData[i - currentTable.partsData.Length].SKU) 
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, currentTable.systemsData[i - currentTable.partsData.Length]);
                    }
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

    }
}
