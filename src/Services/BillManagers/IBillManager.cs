using Sky.Models.Bills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sky.Services.BillManagers
{
    public interface IBillManager
    {
        Task<Bill> GetBillAsync();
    }
}
