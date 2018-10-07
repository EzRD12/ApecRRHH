using System;
using System.Collections.Generic;

namespace Core.Models
{
    public sealed class CandidateEmployee
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public ISet<CandidateInterview> Interviews { get; set; }
    }
}
