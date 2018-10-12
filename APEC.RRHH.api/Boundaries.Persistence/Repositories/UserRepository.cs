using Boundaries.Persistence.Context;
using Core.Models;
using Core.Ports.Repositories;

namespace Boundaries.Persistence.Repositories
{
    public sealed class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApecRrhhContext _dbContext;

        public UserRepository(ApecRrhhContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
