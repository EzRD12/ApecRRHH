using Core.Enums;
using System;
using System.Collections.Generic;
using Core.Contracts;

namespace Core.Models
{
    public sealed class Job : IEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public RiskLevel RiskLevel { get; set; }
        public int MinimumSalary { get; set; }
        public int MaximumSalary { get; set; }
        public int QuantityOfEmployeesNeeded { get; set; }
        public FeatureStatus Status { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public Departament Departament { get; set; }
        public Guid DepartamentId { get; set; }
        public ISet<Employee> Employees { get; set; }
        public ISet<JobCompetence> JobCompetences { get; set; }
        public ISet<JobLanguage> JobLanguages { get; set; }
        public int MinimumYearsExperienceLaboral { get; set; }
    }
}
