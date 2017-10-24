using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LinkShortener.Controllers
{
    using Common.Interfaces.Models;
    using Common.Interfaces.Services;

    using Models.RequestPatameters.Links;

    public class LinksController : ApiController
    {
        public static readonly String UserKey = "userkey";
        
        private readonly ILinksService mLinkService;

        private Guid UserGuid => Guid.Parse(HttpContext.Current.Request.Cookies[UserKey].Value);

        public LinksController(ILinksService linkService)
        {
            mLinkService = linkService;
        }

        public async Task<ILink> Post(CreateRequestParameter param)
        {
            Uri uri;
            if (!ModelState.IsValid || !Uri.TryCreate(param.Link, UriKind.Absolute, out uri))
            {
                throw new Exception("Incorrect URL");
            }
            return await mLinkService.Create(param.Link, UserGuid);
        }

        public async Task<IEnumerable<ILinkInformation>> Get()
        {
            return await mLinkService.GetAll(UserGuid);
        }
    }
}