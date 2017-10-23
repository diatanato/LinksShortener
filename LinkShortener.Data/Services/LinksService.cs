using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkShortener.Data.Services
{
    using Common.Interfaces.Models;
    using Common.Interfaces.Services;

    using Generators.Interfaces;
    using Models;
    using Repositories.Interfaces;

    public class LinksService : ILinksService
    {
        private readonly ILinksRepository  mLinksRepository;
        private readonly IUsersRepository  mUsersRepository;
        private readonly IClicksRepository mClicksRepository;
        private readonly IHashGenerator    mHashGenerator;

        public LinksService(
            ILinksRepository linksRepository,
            IUsersRepository usersRepository,
            IClicksRepository clicksRepository,
            IHashGenerator hashGenerator)
        {
            if (linksRepository == null)
                throw new ArgumentNullException(nameof(linksRepository));
            if (usersRepository == null)
                throw new ArgumentNullException(nameof(usersRepository));
            if (clicksRepository == null)
                throw new ArgumentNullException(nameof(clicksRepository));
            if (hashGenerator == null)
                throw new ArgumentNullException(nameof(hashGenerator));

            mLinksRepository  = linksRepository;
            mUsersRepository  = usersRepository;
            mClicksRepository = clicksRepository;
            mHashGenerator    = hashGenerator;
        }

        #region ILinkService

        public async Task<String> Create(String link, Guid user)
        {
            var entity = new Link
            {
                ShortLink = mHashGenerator.GetHash(link),
                OriginalLink = link,
                CreationDate = DateTime.Now,
                UserId = (await mUsersRepository.FirstOrDefaultAsync(m => m.UserKey == user))?.Id ?? 0
            };
            if (entity.UserId == 0)
            {
                entity.User = new User {UserKey = user};
            }
            await mLinksRepository.CreateAsync(entity);

            return await Task<String>.Factory.StartNew(() => entity.ShortLink);
        }

        public Task<IEnumerable<ILinkInformation>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ILinkInformation>> GetAll(Guid user)
        {
            var links = await mLinksRepository.FindAsync(x => x.User.UserKey == user);
            var result = links.Select(x => new LinkInformationcs
            {
                ShortLink = x.ShortLink,
                OriginalLink = x.OriginalLink,
                CreationDate = x.CreationDate,
                Count = x.Clicks.Count
            }).ToList();
            return result;
        }

        public async Task<String> Get(String link)
        {
            var entity = await mLinksRepository.FirstOrDefaultAsync(m => m.ShortLink == link);

            if (entity == null)
            {
                return null;
            }
            await mClicksRepository.CreateAsync(new Click
            {
                LinkId    = entity.Id,
                Timestamp = DateTime.Now
            });
            return entity.OriginalLink;
        }

        #endregion

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!mDisposed)
            {
                if (disposing)
                {
                    mLinksRepository.Dispose();
                    mUsersRepository.Dispose();
                    mClicksRepository.Dispose();
                }
            }
            mDisposed = true;
        }
        private bool mDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
