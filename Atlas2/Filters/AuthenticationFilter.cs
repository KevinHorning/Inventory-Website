using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Atlas2
{
    public class AuthenticationFilter : FilterAttribute, IActionFilter
    {
        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            HttpActionExecutedContext executedContext = new HttpActionExecutedContext(actionContext, null);

            try
            {
                if (!actionContext.Request.Headers.Contains("userToken"))
                {
                    executedContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
                else
                {
                    var tokenString = actionContext.Request.Headers.GetValues("userToken").FirstOrDefault();

                    //TODO check database if token is valid
                    bool isTokenValid = true;

                    if (isTokenValid)
                    {
                        //valid token, populate the context with useful information and continue to request
                        HttpContext.Current.Items["token"] = tokenString;
                        executedContext.Response = await continuation();
                    }
                    else
                    {
                        //invalid token, reject request
                        executedContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    }
                }
            }
            catch (Exception ex)
            {
                executedContext = new HttpActionExecutedContext(actionContext, ex);
            }

            return executedContext.Response;
        }
    }
}
