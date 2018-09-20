using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using Atlas2.Controllers;
using Atlas2.Models;
using System.Web.Mvc;

namespace Atlas2.Controllers
{
    [System.Web.Http.RoutePrefix("api/LogIn")]
    public class LogInController : ApiController
    {

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("message")]
        public HttpResponseMessage GetMessage()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello");
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("")]
        public HttpResponseMessage LogInRequest(Account model)
        {
            if (model.Username.Equals("Fake@Example") && model.Password.Equals("Password"))
                return Request.CreateResponse(HttpStatusCode.OK, "Log In Successful.");
            else return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Log In Not Successful");
                }

    }
}
