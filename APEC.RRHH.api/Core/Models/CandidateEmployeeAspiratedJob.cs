using System;
using Core.Contracts;
using Core.Enums;

namespace Core.Models
{
    public sealed class CandidateEmployeeAspiratedJob : IEntityBase
    {
        public Guid Id { get; set; }
        public Guid CandidateEmployeeId { get; set; }
        public CandidateEmployee CandidateEmployee { get; set; }
        public Guid JobId { get; set; }
        public Job Job { get; set; }
        public FeatureStatus Status { get; set; }
        public int SalaryToAspire { get; set; }
        public Guid? UserIdWhoRecommendedIt { get; set; }
        public User UserWhoRecomendedIt { get; set; }
    }
}
