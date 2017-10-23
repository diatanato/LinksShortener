using System;

namespace LinkShortener.Data.Repositories.Interfaces
{
    using Common.Interfaces.Repositories;

    using Models;

    public interface ILinksRepository : IRepository<Link, Int32>
    {
    }
}
