﻿using Core.Enums;
using System;

namespace Core.Models
{
    public sealed class Preparation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public AcademicLevel AcademicLevel { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateUp { get; set; }
        public string Institution { get; set; }
    }
}
