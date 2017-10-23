using System;
using System.Data.Entity;

namespace LinkShortener.Data.Repositories
{
    using Interfaces;
    using Models;

    public class LinksRepository : Repository<Link, Int32>, ILinksRepository
    {
        public LinksRepository(DbContext context) : base(context)
        {

        }
    }
}
