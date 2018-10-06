using Boundaries.Persistence.Context;
using Core.Contracts;
using Core.Enums;
using Core.Models;
using Core.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Boundaries.Persistence.Repositories
{
    public sealed class JobRepository: BaseRepository<Job> , IJobRepository
    {
        private readonly ApecRrhhContext _dbContext;
        public JobRepository(ApecRrhhContext dbContext) : base(dbContext) 
            => _dbContext = dbContext;

        IOperationResult<IEnumerable<Employee>> IJobRepository.DeleteJob(Guid jobId)
        {
            IEnumerable<Employee> employees = _dbContext.Employees.Where(employee => employee.JobId == jobId);

            foreach (var employee in employees)
            {
                employee.Status = FeatureStatus.Disabled;
            }

            _dbContext.SaveChanges();

            return BasicOperationResult<IEnumerable<Employee>>.Ok(employees);
        }
    }
}
