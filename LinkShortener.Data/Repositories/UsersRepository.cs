using System;
using System.Data.Entity;

namespace LinkShortener.Data.Repositories
{
    using Interfaces;
    using Models;

    public class UsersRepository : Repository<User, Int32>, IUsersRepository
    {
        public UsersRepository(DbContext context) : base(context)
        {

        }
    }
}
