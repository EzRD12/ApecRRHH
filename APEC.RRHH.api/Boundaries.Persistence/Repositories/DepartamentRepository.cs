using Boundaries.Persistence.Context;
using Core.Contracts;
using Core.Enums;
using Core.Models;
using Core.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Boundaries.Persistence.Repositories
{
    public sealed class DepartamentRepository: BaseRepository<Departament>, IDepartamentRepository
    {
        private readonly ApecRrhhContext _dbContext;

        public DepartamentRepository(ApecRrhhContext dbContext) : base(dbContext) 
            => _dbContext = dbContext;

        IOperationResult<IEnumerable<Job>> IDepartamentRepository.DeleteDepartament(Guid departamentId)
        {
            IEnumerable<Job> jobs = _dbContext.Jobs.Where(job => job.DepartamentId == departamentId);

            foreach (var employee in jobs)
            {
                employee.Status = FeatureStatus.Disabled;
            }

            _dbContext.SaveChanges();

            return BasicOperationResult<IEnumerable<Job>>.Ok(jobs);
        }

        IEnumerable<Departament> IDepartamentRepository.GetAll()
        {
            IEnumerable<Departament> departaments = _dbContext.Departaments.Include(departament => departament.Jobs).AsEnumerable();
            return departaments;
        }
    }
}
