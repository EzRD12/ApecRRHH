using Boundaries.Persistence.Context;
using Core.Models;
using Core.Ports.Repositories;

namespace Boundaries.Persistence.Repositories
{
    public sealed class PreparationRepository: BaseRepository<Preparation>, IPreparationRepository
    {
        private readonly ApecRrhhContext _dbContext;

        public PreparationRepository(ApecRrhhContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
