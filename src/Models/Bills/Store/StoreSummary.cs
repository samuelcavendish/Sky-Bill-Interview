using System;
using System.Collections.Generic;

namespace Sky.Models.Bills.Store
{
    public class StoreSummary
    {
        public IEnumerable<Film> Rentals { get; set; } = new List<Film>();
        public IEnumerable<Film> BuyAndKeep { get; set; } = new List<Film>();
        public Decimal Total { get; set; }
    }
}
