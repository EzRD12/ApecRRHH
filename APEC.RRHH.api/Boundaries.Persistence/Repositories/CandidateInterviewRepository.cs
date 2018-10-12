using Boundaries.Persistence.Context;
using Core.Models;
using Core.Ports.Repositories;

namespace Boundaries.Persistence.Repositories
{
    public sealed class CandidateInterviewRepository : BaseRepository<CandidateInterview>, ICandidateInterviewRepository
    {
        private readonly ApecRrhhContext _dContext;
        public CandidateInterviewRepository(ApecRrhhContext dContext) : base(dContext)
        {
            _dContext = dContext;
        }
    }
}
