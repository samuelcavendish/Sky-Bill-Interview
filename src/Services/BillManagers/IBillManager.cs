using Sky.Models.Bills;
using System.Threading.Tasks;

namespace Sky.Services.BillManagers
{
    public interface IBillManager
    {
        Task<Bill> GetBillAsync();
    }
}
