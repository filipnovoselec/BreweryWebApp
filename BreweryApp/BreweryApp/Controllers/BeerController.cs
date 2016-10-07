using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using AngularJSWebApiEmpty.Models;

namespace AngularJSWebApiEmpty.Controllers
{
    //[RoutePrefix("api/Beer")]
    public class BeerController : Controller
    {
        [System.Web.Http.Route("GetInfo")]
        [System.Web.Http.HttpGet]
        public Boolean GetInfo()
        {
            using (var db = new BreweryEntities())
            {
                if (db.Beers.FirstOrDefault(b => b.EndDate > DateTime.Now) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //[Route("GetBeer")]
        [System.Web.Http.HttpGet]
        public JsonResult GetBeer()
        {
            using (var db = new BreweryEntities())
            {
                var beer = db.Beers.OrderByDescending(b => b.StartDate).First();
                var nbeer= new CompleteBeer()
                {
                    Id = beer.Id,
                    Name = beer.Name,
                    StartDate = beer.StartDate,
                    EndDate = beer.EndDate,
                    Time = (int)beer.EndDate.Subtract(DateTime.Now).TotalSeconds,
                    TotalTime = (int)beer.EndDate.Subtract(beer.StartDate).TotalSeconds,
                    Temperature = db.Temperatures.Where(b => b.BeerId == beer.Id).OrderByDescending(b => b.Id).Take(100).OrderBy(b => b.Id).
                    Select(b => b.Temp).ToList(),
                    ReadTime = db.Temperatures.Where(b => b.BeerId == beer.Id).OrderByDescending(b => b.Id).Take(100).OrderBy(b => b.Id)
                    .Select(b => b.Time).ToList()

                };
                return Json(nbeer, JsonRequestBehavior.AllowGet);
            }
        }

        //public List<string> ShortenLabels(List<DateTime> oldLabels)
        //{
        //    var
        //    foreach (var ele in oldLabels)
        //    {

        //    }
        //}
    }
}
