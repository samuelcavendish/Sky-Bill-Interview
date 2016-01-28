using System;
using System.Collections.Generic;

namespace Sky.Models.Bills.Subscriptions
{
    public class PackageSummary
    {
        public IEnumerable<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public Decimal Total { get; set; }
    }
}
