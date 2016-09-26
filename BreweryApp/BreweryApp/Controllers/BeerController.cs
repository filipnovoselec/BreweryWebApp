using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularJSWebApiEmpty.Models;

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

        [Route("GetBeer")]
        [HttpGet]
        public CompleteBeer GetBeer()
        {
            using (var db = new BreweryEntities())
            {
                var beer = db.Beers.OrderByDescending(b => b.StartDate).First();
                return new CompleteBeer()
                {
                    Id = beer.Id,
                    Name=beer.Name,
                    StartDate = beer.StartDate,
                    EndDate = beer.EndDate,
                    Time = (int) beer.EndDate.Subtract(DateTime.Now).TotalSeconds,
                    TotalTime = (int)beer.EndDate.Subtract(beer.StartDate).TotalSeconds,
                    Temperature = db.Temperatures.Where(b => b.BeerId == beer.Id).Select(b => b.Temp).ToList(),
                    ReadTime = db.Temperatures.Where(b => b.BeerId == beer.Id).Select(b => b.Time).ToList()

            };
            }
        }
    }
}
