using System;
using System.Web.Mvc;

namespace LinkShortener.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(String id)
        {
            if (!String.IsNullOrWhiteSpace(id))
            {
                return Redirect("http://yandex.ru");
            }
            return View();
        }
    }
}