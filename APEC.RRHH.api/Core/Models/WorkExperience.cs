using Core.Enums;
using System;
using Core.Contracts;

namespace Core.Models
{
    public sealed class WorkExperience : IEntityBase
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string PositionHeld { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateUp { get; set; }
        public int YearExperiences => DateTime.Compare(DateFrom, DateUp);
        public int Salary { get; set; }
        public CurrencyType CurrencyType { get; set; }
    }
}
