using Boundaries.Persistence.Context;
using Core.Models;
using Core.Ports.Repositories;

namespace Boundaries.Persistence.Repositories
{
    public sealed class CompetenceRepository: BaseRepository<Competence>, ICompetenceRepository
    {
        private readonly ApecRrhhContext _dbContext;
        public CompetenceRepository(ApecRrhhContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
