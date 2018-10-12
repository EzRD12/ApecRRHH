using System;
using Core.Contracts;

namespace Core.Models
{
    public sealed class CandidateInterview : IEntityBase
    {
        public Guid Id { get; set; }
        public Guid CandidateEmployeeId { get; set; }
        public CandidateEmployee CandidateEmployee { get; set; }
        public Guid CandidateEmployeeAspiratedJobId { get; set; }
        public CandidateEmployeeAspiratedJob CandidateEmployeeAspiratedJob { get; set; }
        public Guid JobId { get; set; }
        public Job Job { get; set; }
        public DateTime InterviewDate { get; set; }
        public Guid EmployeeIdWhoInterviewed { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeNotes { get; set; }
        public bool Hired { get; set; }
    }
}
