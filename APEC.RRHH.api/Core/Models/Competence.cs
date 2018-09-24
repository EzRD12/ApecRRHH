using Core.Enums;
using System;

namespace Core.Models
{
    /// <summary>
    /// Represents a competence of an user
    /// </summary>
    public sealed class Competence
    {
        /// <summary>
        /// Represents the competence's identification
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Represents the competence's description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Represents the status of the competence
        /// </summary>
        public FeatureStatus Status { get; set; }
    }
}
