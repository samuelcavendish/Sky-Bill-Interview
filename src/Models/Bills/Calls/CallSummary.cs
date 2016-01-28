using System;
using System.Collections.Generic;

namespace Sky.Models.Bills.Calls
{
    public class CallSummary
    {
        public IEnumerable<Call> Calls { get; set; } = new List<Call>();
        public Decimal Total { get; set; }
    }
}
