using System;

namespace Core.Models
{
    public sealed class CandidateEmployeeAspiratedJob
    {
        public Guid CandidateEmployeeId { get; set; }
        public CandidateEmployee CandidateEmployee { get; set; }
        public Guid JobId { get; set; }
        public Job Job { get; set; }
        public int SalaryToAspire { get; set; }
        public Guid? UserIdWhoRecommendedIt { get; set; }
    }
}
