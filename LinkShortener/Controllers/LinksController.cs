using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LinkShortener.Controllers
{
    using Common.Interfaces.Services;

    using Models.RequestPatameters.Links;

    public class LinksController : ApiController
    {
        public static readonly String UserKey = "userkey";

        private readonly ILinksService mLinkService;

        public LinksController(ILinksService linkService)
        {
            mLinkService = linkService;
        }

        [HttpPost]
        public async Task<String> Create(CreateRequestParameter param)
        {
            return ConfigurationManager.AppSettings["RealHost"] + await mLinkService.Create(param.Link, Guid.Parse(HttpContext.Current.Request.Cookies[UserKey].Value));
        }
    }
}