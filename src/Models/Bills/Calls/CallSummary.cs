using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sky.Models.Bills.Calls
{
    public class CallSummary
    {
        public IEnumerable<Call> Calls { get; set; } = new List<Call>();
        public Decimal Total { get; set; }
    }
}
