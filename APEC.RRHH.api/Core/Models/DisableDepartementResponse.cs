using System.Collections.Generic;

namespace Core.Models
{
    public sealed class DisableDepartementResponse
    {
        public DisableDepartementResponse(IEnumerable<Job> jobs, IEnumerable<Employee> enumerable)
        {
            Jobs = jobs;
            Enumerable = enumerable;
        }

        public IEnumerable<Job> Jobs { get; }
        public IEnumerable<Employee> Enumerable { get; }
    }
}