using Core.Enums;
using System;

namespace Core.Models
{
    public sealed class Language
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public FeatureStatus Status { get; set; }
    }
}
