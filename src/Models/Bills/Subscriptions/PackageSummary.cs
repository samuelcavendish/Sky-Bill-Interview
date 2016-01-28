using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sky.Models.Bills.Subscriptions
{
    public class PackageSummary
    {
        public IEnumerable<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public Decimal Total { get; set; }
    }
}
