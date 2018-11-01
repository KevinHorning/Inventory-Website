﻿using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Atlas2.Controllers
{
    [RoutePrefix("api/Equipment")]
    public class EquipmentController : ApiController
    {
        [HttpGet]
        [Route("table")]
        public HttpResponseMessage TableInfo()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Backend.Shared.TableData.getTableData("equipment"));
        }

        //[HttpPost]
        //[Route("searchRequest")]
        //public HttpRequestMessage SearchInfo(SearchFilter model)
        //{
        //    return Request.CreateResponseResponse(HttpStatusCode.OK, DatabaseTableResultMethod("equipment", model));
        //}
    }
}
