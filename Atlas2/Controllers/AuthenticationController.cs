using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Atlas2.Controllers
{
    [RoutePrefix("api/authentication")]
    public class AuthenticationController : ApiController
    {
        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> TestMethod()
        {
            return Request.CreateResponse(HttpStatusCode.OK, $"WHAT UP WORLD: ");
        }

        [HttpGet]
        [Route("two")]
        [AuthenticationFilter]
        public async Task<HttpResponseMessage> Testmethod2()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "oh hi");
        }
    }
}
