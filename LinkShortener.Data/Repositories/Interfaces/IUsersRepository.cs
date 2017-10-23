using System;

namespace LinkShortener.Data.Repositories.Interfaces
{
    using Common.Interfaces.Repositories;

    using Models;

    public interface IUsersRepository : IRepository<User, Int32>
    {
    }
}