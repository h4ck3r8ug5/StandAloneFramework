using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MediaCentre.Models;

namespace MediaCentre.Controllers
{
    public class HomeController : Controller
    {
       [HttpGet]
        public ActionResult Index()
       {
           var products = new List<Product>();

           using (var context = new MediaCentreEntities())
           {
               products = (from product in context.Years
                           select new Product
                           {
                               Id = product.Id,
                               Description = product.Value
                           }
                   
                   ).ToList(); 
           }

           return View("ProductPartial", products);
        }

    }
}
