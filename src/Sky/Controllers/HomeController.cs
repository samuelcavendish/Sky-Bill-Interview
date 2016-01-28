using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using Sky.Models;
using Sky.Services.BillManagers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sky.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBillManager _billManager;
        public HomeController(IBillManager billManager)
        {
            _billManager = billManager;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var bill = await _billManager.GetBillAsync();
            return View(bill);
        }
    }
}
