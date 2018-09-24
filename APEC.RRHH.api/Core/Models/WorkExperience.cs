﻿using Core.Enums;
using System;

namespace Core.Models
{
    public sealed class WorkExperience
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string PositionHeld { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateUp { get; set; }
        public int Salary { get; set; }
        public CurrencyType CurrencyType { get; set; }
    }
}
