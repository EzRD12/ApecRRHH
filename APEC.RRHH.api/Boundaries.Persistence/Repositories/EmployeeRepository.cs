using Boundaries.Persistence.Context;
using Core.Models;
using Core.Ports.Repositories;

namespace Boundaries.Persistence.Repositories
{
    public sealed class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly ApecRrhhContext _dContext;
        public EmployeeRepository(ApecRrhhContext dContext) : base(dContext)
        {
            _dContext = dContext;
        }
    }
}
