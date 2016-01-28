using System;

namespace Sky.Models.Bills.Statements
{
    public class Statement
    {
        public DateTime Generated { get; set; }
        public DateTime Due { get; set; }
        public DateRange Period { get; set; }
    }
}
