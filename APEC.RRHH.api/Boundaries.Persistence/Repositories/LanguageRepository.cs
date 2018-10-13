using Boundaries.Persistence.Context;
using Core.Models;
using Core.Ports.Repositories;

namespace Boundaries.Persistence.Repositories
{
    public sealed class LanguageRepository: BaseRepository<Language>, ILanguageRepository
    {
        private readonly ApecRrhhContext _dbContext;

        public LanguageRepository(ApecRrhhContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
