using ShuperShoesApp.Entities.Results;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace SuperShoesApp.Api.Filters
{
    public class BasicAuthenticationAttribute : System.Web.Http.Filters.AuthorizationFilterAttribute
    {

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            try
            {

                if (actionContext.Request.Headers.Authorization == null)
                {

                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);

                }

                else
                {
                    var httpRequestHeader = actionContext.Request.Headers.GetValues("Authorization").FirstOrDefault();

                    httpRequestHeader = httpRequestHeader.Substring("Authorization".Length);

                    string[] httpRequestHeaderValues = httpRequestHeader.Split(':');

                    string username = Encoding.UTF8.GetString(Convert.FromBase64String(httpRequestHeaderValues[0]));

                    string password = Encoding.UTF8.GetString(Convert.FromBase64String(httpRequestHeaderValues[1]));

                    if (!username.Equals(ConfigurationManager.AppSettings["user"]) || !password.Equals(ConfigurationManager.AppSettings["password"]))
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(new Result() { Error_code = 401, Success = false, Error_msg = "Error de autenticación del servicio" });
                    }

                }

            }

            catch
            {

                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);

            }

        }

    }
}