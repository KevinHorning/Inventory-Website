using System.Net;
using System.Net.Http;
using System.Web.Http;
using Atlas2.Models;

namespace Atlas2.Controllers
{
    [RoutePrefix("api/Contacts")]
    public class ContactsController : ApiController
    {
        [HttpGet]
        [Route("table")]
        public HttpResponseMessage TableInfo()
        {
            //return Request.CreateResponse(HttpStatusCode.OK, Backend.Shared.TableData.GetTableData("contact"));
            return Request.CreateResponse(HttpStatusCode.OK,
                new TableResponse<Contact>
                {
                Headers = new[] 
                {
                        "Id",
                        "Name",
                        "Address",
                        "Email",
                        "Phone"
                    },
                    Data = new[]
                    {
                        new Contact
                        {
                            Address = "test address 1",
                            Email = "test@email1.com",
                            Id = 1,
                            Name = "Test Name",
                            Phone = "777-777-7777"
                        },
                        new Contact
                        {
                            Address = "test address 2",
                            Email = "test@email12.com",
                            Id = 2,
                            Name = "Test Name 2",
                            Phone = "777-777-7772"
                        },
                        new Contact
                        {
                            Address = "test address 3",
                            Email = "test@email3.com",
                            Id = 3,
                            Name = "Test Name 3",
                            Phone = "777-777-7773"
                        },
                        new Contact
                        {
                            Address = "test address 4",
                            Email = "test@email4.com",
                            Id = 4,
                            Name = "Test Name 4",
                            Phone = "777-777-7774"
                        }
                    }
                });
            }

        //[HttpPost]
        //[Route("searchRequest")]
        //public HttpRequestMessage SearchInfo(Searchfilter model)
        //{
        //    return Request.CreateResponseResponse(HttpStatusCode.OK, DatabaseTableResultMethod("contact", model));
        //}
    }
}
