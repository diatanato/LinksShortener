using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace LinkShortener.Controllers
{
    using Models.RequestPatameters.Links;

    using Common.Interfaces.Models;
    using Common.Interfaces.Services;

    public class LinksController : ApiController
    {
        private readonly ILinksService mLinkService;

        public LinksController(ILinksService linkService)
        {
            mLinkService = linkService;
        }

        [HttpPost]
        public async Task<String> Create(CreateRequestParameter param)
        {
            return await mLinkService.Create(param.Link, Guid.NewGuid());
        }
    }
}