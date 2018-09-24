using System;

namespace Core.Models
{
    public sealed class UserCompetence
    {
        public Guid UserId { get; set; }
        public Guid CompetenceId { get; set; }
        public User User { get; set; }
        public Competence Competence { get; set; }
    }
}
