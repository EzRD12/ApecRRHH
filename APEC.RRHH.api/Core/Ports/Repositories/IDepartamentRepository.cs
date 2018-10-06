using System;
using System.Collections.Generic;
using Core.Contracts;
using Core.Models;

namespace Core.Ports.Repositories
{
    public interface IDepartamentRepository : IGenericRepository<Departament>
    {
        IOperationResult<IEnumerable<Job>> DeleteDepartament(Guid departamentId);

    }
}
