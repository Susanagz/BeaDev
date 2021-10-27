using System;
using System.Collections.Generic;

#nullable disable

namespace Model
{
    public partial class ProgrammingLanguage
    {
        public string Id { get; set; }
        public string IdIcon { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        public decimal? SalaryRange { get; set; }
        public string StackDescription { get; set; }
        public DateTime RegistryDate { get; set; }

        public virtual ProgrammingIcon IdIconNavigation { get; set; }
    }
}
