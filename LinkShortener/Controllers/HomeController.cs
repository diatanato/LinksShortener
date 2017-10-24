using System.Web.Mvc;

namespace LinkShortener.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}