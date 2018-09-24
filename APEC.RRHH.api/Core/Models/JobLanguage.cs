using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public sealed class JobLanguage
    {
        public Guid JobId { get; set; }
        public Guid LanguageId { get; set; }
        public Job Job { get; set; }
        public Language Type { get; set; }
    }
}
