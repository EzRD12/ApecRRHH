using System;

namespace Core.Models
{
    public sealed class JobCompetence
    {
        public Guid JobId { get; set; }
        public Guid CompetenceId { get; set; }
        public Job Job { get; set; }
        public Competence Competence { get; set; }
    }
}
