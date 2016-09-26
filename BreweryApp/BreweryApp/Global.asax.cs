using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using AngularJSWebApiEmpty.Controllers;

namespace BreweryApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Thread serialThread = new Thread(new ThreadStart(SerialController.ReceiveSerial));
            serialThread.Start();
            serialThread.IsBackground = true;
        }
    }
}
