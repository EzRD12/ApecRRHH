using System;
using System.Collections.Generic;
using Core.Contracts;
using Core.Models;

namespace Core.Ports.Repositories
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        IOperationResult<IEnumerable<Employee>> DeleteJob(Guid jobId);
    }
}
