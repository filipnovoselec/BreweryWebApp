using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularJSWebApiEmpty.Controllers
{
    [RoutePrefix("api/Beer")]
    public class BeerController : ApiController
    {
        [Route("GetInfo")]
        [HttpGet]
        public bool GetInfo()
        {
            return true;
        }
    }
}
