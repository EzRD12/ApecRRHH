using Boundaries.Persistence.Context;
using Core.Models;
using Core.Ports.Repositories;

namespace Boundaries.Persistence.Repositories
{
    public sealed class CandidateEmployeeRepository: BaseRepository<CandidateEmployee>, ICandidateEmployeeRepository
    {
        private readonly ApecRrhhContext _dContext;
        public CandidateEmployeeRepository(ApecRrhhContext dContext) : base(dContext)
        {
            _dContext = dContext;
        }
    }
}
