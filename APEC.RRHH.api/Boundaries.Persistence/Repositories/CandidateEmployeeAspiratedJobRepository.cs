using Boundaries.Persistence.Context;
using Core.Models;
using Core.Ports.Repositories;

namespace Boundaries.Persistence.Repositories
{
    public sealed class CandidateEmployeeAspiratedJobRepository: BaseRepository<CandidateEmployeeAspiratedJob>, ICandidateEmployeeAspiratedJobRepository
    {
        private readonly ApecRrhhContext _dContext;
        public CandidateEmployeeAspiratedJobRepository(ApecRrhhContext dContext) : base(dContext)
        {
            _dContext = dContext;
        }
    }
}
