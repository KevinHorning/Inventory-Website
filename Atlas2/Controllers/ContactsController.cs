using Atlas2.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;
using System.Diagnostics.Contracts;

namespace Atlas2.Controllers
{
    [RoutePrefix("api/Contacts")]
    public class ContactsController : ApiController
    {
        [HttpGet]
        [Route("table")]
        public HttpResponseMessage GetTableArray() {
            Contract.Ensures(Contract.Result<HttpResponseMessage>() != null);

            if (false){
                //bad request
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            string[] Properties = new string[5];
            string[] Elements = new string[15];

            Properties[0] = "ID";
            Properties[1] = "Name";
            Properties[2] = "Phone";
            Properties[3] = "Email";
            Properties[4] = "Address";

            Elements[0] = "1";
            Elements[1] = "Sarah";
            Elements[2] = "555";
            Elements[3] = "Sarah@gmail.com";
            Elements[4] = "1000 House Street";
            Elements[5] = "2";
            Elements[6] = "Chuck";
            Elements[7] = "404";
            Elements[8] = "Chuck@gmail.com";
            Elements[9] = "2000 Apartment Way";
            Elements[10] = "3";
            Elements[11] = "Lisa";
            Elements[12] = "919";
            Elements[13] = "Lis@gmail.com";
            Elements[14] = "3000 Building Lane";

            var a = new TableInfo(Properties, Elements);

            return Request.CreateResponse(a);
        }
    }
}
