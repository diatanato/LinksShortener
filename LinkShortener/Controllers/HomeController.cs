using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LinkShortener.Controllers
{
    using Common.Interfaces.Services;

    public class HomeController : Controller
    {
        private readonly ILinksService mLinkService;

        public HomeController(ILinksService linkService)
        {
            mLinkService = linkService;
        }

        public async Task<ActionResult> Index(String id)
        {
            if (!String.IsNullOrWhiteSpace(id))
            {
                var link = await mLinkService.Get(id);
                if (link != null)
                {
                    return Redirect(link);
                }
            }
            return View();
        }
    }
}