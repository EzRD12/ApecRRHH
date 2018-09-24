using System;
using System.Collections.Generic;
using Core.Enums;

namespace Core.Models
{
    public sealed class CandidateEmployee
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Guid JobToAspire { get; set; }
        public Job Job { get; set; }
        public int SalaryToAspire { get; set; }
        public Guid UserIdWhoRecommendedIt { get; set; }
    }
}
