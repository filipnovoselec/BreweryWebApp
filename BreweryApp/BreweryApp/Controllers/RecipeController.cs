using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularJSWebApiEmpty.Models;

namespace AngularJSWebApiEmpty.Controllers
{
    [RoutePrefix("api/Recipe")]
    public class RecipeController : ApiController
    {
        [Route("GetRecipe")]
        [HttpGet]
        public Recipes GetRecipe([FromUri(Name = "name")] string name)
        {
            using (var db = new BreweryEntities())
            {
                return db.Recipes.FirstOrDefault(b => b.Name == name);
            }
        }

        [Route("GetNames")]
        [HttpGet]
        public List<string> GetRecipeNames()
        {
            using (var db = new BreweryEntities())
            {
                return db.Recipes.Select(b => b.Name).ToList();
            }
        }
    }
}
