using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Atlas2.Models;

namespace Atlas2.Controllers
{
    [RoutePrefix("api/Inventory")]
    public class InventoryController : ApiController
    {
        private static Backend.Models.InventoryTable currentTable;

        [HttpGet]
        [Route("table")]
        public HttpResponseMessage TableInfo(string search)
        {
            var dbManager = new Backend.Managers.DatabaseManager();

            if (search == "part")
            {
                currentTable = dbManager.GetInventoryTable().Result;
                var tableObjects = new List<object>();
                var skus = new Dictionary<string, object>();
                for (int i = 0; i < currentTable.PartsData.Length; i++)
                {
                    if(skus.TryGetValue(currentTable.PartsData[i].SKU as string, out var part)) 
                    {
                        ((Backend.Models.Part)part).count++;
                        skus.Remove(currentTable.PartsData[i].SKU);
                        skus.Add(currentTable.PartsData[i].SKU, part);
                    }
                    else 
                    {
                        skus.Add(currentTable.PartsData[i].SKU, 
                                new Backend.Models.Part
                                {
                                    name = currentTable.PartsData[i].name,
                                    count = currentTable.PartsData[i].count,
                                    itemType = currentTable.PartsData[i].itemType,
                                    SKU = currentTable.PartsData[i].SKU
                                });
                    }
                }

                for (int i = 0; i < currentTable.SystemsData.Length; i++) 
                {
                    if(skus.TryGetValue(currentTable.SystemsData[i].SKU as string, out var system))
                    {
                        ((Backend.Models.System)system).count++;
                        skus.Remove(currentTable.SystemsData[i].SKU);
                        skus.Add(currentTable.SystemsData[i].SKU, system);
                    }
                    else
                    {
                        skus.Add(currentTable.SystemsData[i].SKU,
                            new Backend.Models.System
                            {
                                name = currentTable.SystemsData[i].name,
                                count = currentTable.SystemsData[i].count,
                                itemType = currentTable.SystemsData[i].itemType,
                                SKU = currentTable.SystemsData[i].SKU
                            });
                    }
                }

                foreach(KeyValuePair<string,object> pair in skus)
                {
                    tableObjects.Add(pair.Value);
                }

                var b = new TableInfo
                {
                    Headers = new[] { "name", "SKU", "count", "itemType" },
                    Data = tableObjects.ToArray()
                };
                return Request.CreateResponse(HttpStatusCode.OK, b);
            }
            else if (search == "partSystem")
            {
                return Request.CreateResponse(HttpStatusCode.OK, dbManager.GetSystemsTable());
            }
            else if (search == "systemEdit")
            {
                return Request.CreateResponse(HttpStatusCode.OK, dbManager.GetPartsTable());
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
            for (int i = 0; i < currentTable.PartsData.Length + currentTable.SystemsData.Length; i++) 
            {
                if(i < currentTable.PartsData.Length) 
                {
                    if (sku == currentTable.PartsData[i].SKU)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, currentTable.PartsData[i]);
                    }
                } 
                else 
                {
                    if (sku == currentTable.SystemsData[i - currentTable.PartsData.Length].SKU) 
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, currentTable.SystemsData[i - currentTable.PartsData.Length]);
                    }
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

    }
}
