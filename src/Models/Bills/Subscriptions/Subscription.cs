using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sky.Models.Bills.Subscriptions
{
    public class Subscription
    {
        public String Type { get; set; }
        public String Name { get; set; }
        public Decimal Cost { get; set; }
    }
}
