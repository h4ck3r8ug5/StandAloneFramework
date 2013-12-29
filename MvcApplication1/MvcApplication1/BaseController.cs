using System.Web.Mvc;

namespace MvcApplication1
{
    public class BaseController : Controller
    {
        protected MediaCentreEntities DatabaseContext { get; set; }

        protected BaseController()
        {
            DatabaseContext = new MediaCentreEntities();
        }
    }
}