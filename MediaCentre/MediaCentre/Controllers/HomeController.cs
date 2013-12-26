using System.Linq;
using System.Web.Mvc;

namespace MediaCentre.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var movie = new Models.Movie();

            using (var context = new MediaCentreEntities())
            {
                movie = context.Movie.Select(x => new Models.Movie
                {
                    Description = x.Description,
                    Directors = x.Directors,
                    Genre = "ANimation",
                    Year = 2013,
                    Name = "Turbo",
                    Rating = 6

                }).First();
            }

            return View(movie);
        }
    }
}
