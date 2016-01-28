using System;

namespace Sky.Models.Bills.Calls
{
    public class Call
    {
        public String Called { get; set; }
        public TimeSpan Duration { get; set; }
        public Decimal Cost { get; set; }
    }
}
