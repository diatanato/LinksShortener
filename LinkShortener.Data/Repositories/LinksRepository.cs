using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LinkShortener.Data.Repositories
{
    using Interfaces;
    using Models;

    public class LinksRepository : Repository<Link, Int32>, ILinksRepository
    {
        public LinksRepository(DbContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<Link>> FindAsync(Expression<Func<Link, bool>> where)
        {
            return await Context.Set<Link>().Include(x => x.Clicks).Where(where).ToListAsync();
        }
    }
}
