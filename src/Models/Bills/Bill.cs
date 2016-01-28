using Sky.Models.Bills.Calls;
using Sky.Models.Bills.Statements;
using Sky.Models.Bills.Store;
using Sky.Models.Bills.Subscriptions;
using System;

namespace Sky.Models.Bills
{
    public class Bill
    {
        public Statement Statement { get; set; }
        public PackageSummary Package { get; set; }
        public CallSummary CallCharges { get; set; }
        public StoreSummary SkyStore { get; set; }
        public Decimal Total { get; set; }
    }
}
