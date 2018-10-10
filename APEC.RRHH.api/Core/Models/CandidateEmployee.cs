﻿using System;
using System.Collections.Generic;
using Core.Enums;

namespace Core.Models
{
    public sealed class CandidateEmployee
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public FeatureStatus Status { get; set; }
        public ISet<CandidateInterview> Interviews { get; set; }
    }
}
