﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
﻿using Atlas2.Models;
using System.Net;
using System.Net.Http;
using Atlas2.Controllers;
using Atlas2.Models;
using System.Web.Mvc;
using System.Text;
using System.Security.Cryptography;
using CTG.Database;
using System.Text;
using System.Web.Http;

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
            String hashed = GenerateSHA256String(model.Password); 

            if(CTG.Database.Communication.Login.Authenticate(model.Username, model.Password) == true)
                return Request.CreateResponse(HttpStatusCode.OK, model.Username + "Log In Successful.");
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Log In Not Successful");
        }

        public static string GenerateSHA256String(string inputString)
        {
            SHA256 sha256Hash = SHA256.Create();
            byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes("inputString"));

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                result.Append(data[i].ToString("X2"));
            }

            return result.ToString();
        }

    }
}
