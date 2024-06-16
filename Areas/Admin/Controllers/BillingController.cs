using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Repository;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.Billing;


namespace RehabilitationSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BillingController : Controller
    {
        private readonly IBillingRepository _billingRepo;

        public BillingController(IBillingRepository billingRepo)
        {
            _billingRepo = billingRepo;
        }
        // GET: ProgramController
        public async Task<IActionResult> Index()
        {
            BillingQuery query = new BillingQuery() { };
            List<string> includes = new List<string>() { "" };
            List<GetBilling> BillingVM = await _billingRepo.GetAllAsync(query, includes);
            return View(BillingVM);
        }

        public async Task<IActionResult> FilterBilling(string? paymentStatus)
        {
            Console.WriteLine(paymentStatus + "HAHA");
            BillingQuery query = new BillingQuery() { };
            query.PaymentStatus = paymentStatus == "paid" ? true : paymentStatus == "unpaid" ? false : (bool?)null;
            List<string> includes = new List<string>() { "" };

            // Fetch the filtered data based on paymentStatus
            var billings = await _billingRepo.GetAllAsync(query, includes);

            // Return the partial view containing the filtered table rows
            return PartialView("_BillingTableRows", billings);
        }

        // GET: ProgramController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            return View();
        }

        // GET: ProgramController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgramController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string id)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProgramController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            return View();
        }

        // POST: ProgramController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit()
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProgramController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProgramController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
