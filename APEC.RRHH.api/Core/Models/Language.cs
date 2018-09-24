using Core.Enums;
using System;
using Core.Contracts;

namespace Core.Models
{
    public sealed class Language : IEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public FeatureStatus Status { get; set; }
    }
}
