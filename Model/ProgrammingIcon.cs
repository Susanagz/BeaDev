using System;
using System.Collections.Generic;

#nullable disable

namespace Model
{
    public partial class ProgrammingIcon
    {
        public ProgrammingIcon()
        {
            ProgrammingLanguages = new HashSet<ProgrammingLanguage>();
        }

        public string Id { get; set; }
        public string Content { get; set; }

        public virtual ICollection<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    }
}
