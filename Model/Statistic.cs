using System;
using System.Collections.Generic;

#nullable disable

namespace Model
{
    public partial class Statistic
    {
        public string Id { get; set; }
        public int TotalOffers { get; set; }
        public int MonthID { get; set; }
        public int ProgrammLangID { get; set; }
    }
}
