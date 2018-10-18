using Core.Contracts;
using Core.Enums;
using System;
using System.Collections.Generic;

namespace Core.Models
{
    public sealed class User : IEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{Name} {LastName}";
        public string Identification { get; set; }
        public IdentificationType IdentificationType { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ISet<UserCompetence> UserCompetences { get; set; }
        public ISet<UserLanguage> Languages { get; set; }
        public ISet<Preparation> Preparations { get; set; }
        public ISet<WorkExperience> WorkExperiences { get; set; }
        public Role CurrentRole { get; set; }
    }
}
