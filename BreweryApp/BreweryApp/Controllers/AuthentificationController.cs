using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularJSWebApiEmpty.Models;

namespace AngularJSWebApiEmpty.Controllers
{
    [RoutePrefix("api/Authentification")]
    public class AuthentificationController : ApiController
    {
        
        [Route("Authentificate")]
        [HttpPost]
        public HttpResponseMessage Authentificate([FromUri (Name = "username")]string username, [FromUri(Name = "password")]string password)
        {
            using (var db = new BreweryEntities())
            {
                var user = db.Authentification.First(b => b.UserName == username);
                if (user!=null)
                {
                    if (user.Password == password)
                    {
                        return new HttpResponseMessage(HttpStatusCode.Accepted);
                    }
                    else
                    {
                        return new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    }
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
            }
        }

    }
}
