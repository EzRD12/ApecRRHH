using System;
using System.Collections.Generic;
using Core.Contracts;
using Core.Enums;

namespace Core.Models
{
    public sealed class CandidateEmployee : IEntityBase
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public FeatureStatus Status { get; set; }
        public ISet<CandidateInterview> Interviews { get; set; }
        public ISet<CandidateEmployeeAspiratedJob> CandidateEmployeeAspiratedJobs { get; set; }
    }
}
