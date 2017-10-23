using System;

namespace LinkShortener.Data.Repositories.Interfaces
{
    using Common.Interfaces.Repositories;

    using Models;

    public interface IClicksRepository : IRepository<Click, Int32>
    {
    }
}
