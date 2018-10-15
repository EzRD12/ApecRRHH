using System.Collections.Generic;
using System.Linq;
using Boundaries.Persistence.Context;
using Core.Models;
using Core.Ports.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Boundaries.Persistence.Repositories
{
    public sealed class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly ApecRrhhContext _dContext;
        public EmployeeRepository(ApecRrhhContext dContext) : base(dContext)
        {
            _dContext = dContext;
        }

        IEnumerable<Employee> IEmployeeRepository.GetAll() 
            => _dContext.Employees
            .Include(employee => employee.Job)
            .Include(employee => employee.User)
            .AsEnumerable();
    }
}
