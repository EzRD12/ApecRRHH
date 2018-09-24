using System;

namespace Core.Models
{
    public sealed class UserLanguage
    {
        public Guid UserId { get; set; }
        public Guid LanguageId { get; set; }
        public User User { get; set; }
        public Language Language { get; set; }
    }
}
