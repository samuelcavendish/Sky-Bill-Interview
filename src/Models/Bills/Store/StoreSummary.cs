using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sky.Models.Bills.Store
{
    public class StoreSummary
    {
        public IEnumerable<Film> Rentals { get; set; } = new List<Film>();
        public IEnumerable<Film> BuyAndKeep { get; set; } = new List<Film>();
        public Decimal Total { get; set; }
    }
}
