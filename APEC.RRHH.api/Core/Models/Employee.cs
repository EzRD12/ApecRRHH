using System;
using Core.Enums;

namespace Core.Models
{
    public sealed class Employee
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime AdmissionDate { get; set; }
        public Guid JobId { get; set; }
        public Job Job { get; set; }
        public int MonthlySalary { get; set; }
    }
}
