using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace AngularJSWebApiEmpty.Hubs
{
    public class BeerHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}