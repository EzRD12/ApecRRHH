using Core.Enums;
using System;
using System.Collections.Generic;
using Core.Contracts;

namespace Core.Models
{
    public sealed class Departament : IEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public FeatureStatus Status { get; set; }
        public ISet<Job> Jobs { get; set; }
    }
}
