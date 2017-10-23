using System;
using System.Data.Entity;

namespace LinkShortener.Data.Repositories
{
    using Interfaces;
    using Models;

    public class ClicksRepository : Repository<Click, Int32>, IClicksRepository
    {
        public ClicksRepository(DbContext context) : base(context)
        {

        }
    }
}
