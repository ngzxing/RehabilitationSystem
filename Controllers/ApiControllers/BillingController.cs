using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.Billing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RehabilitationSystem.Controllers.ApiControllers
{
    [Route("api/Billing")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IBillingRepository _billingRepo;

        public BillingController(IBillingRepository billingRepo)
        {
            _billingRepo = billingRepo;
        }

        // GET: api/Billing
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] BillingQuery query)
        {
            List<string> includes = new List<string> { "BillingItems" };
            List<GetBilling>? billings = await _billingRepo.GetAllAsync(query, includes);

            if (billings == null || billings.Count == 0)
            {
                return NotFound("No billings found.");
            }

            return Ok(billings);
        }

        // GET: api/Billing/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            List<string> includes = new List<string> { "BillingItems" };
            GetBilling? billing = await _billingRepo.GetByIdAsync(id, includes);

            if (billing == null)
            {
                return NotFound("Billing not found.");
            }

            return Ok(billing);
        }

        // PUT: api/Billing/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaymentStatus([FromRoute] string id, [FromBody] UpdateBilling updateBilling)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string? result = await _billingRepo.UpdateAsync(id, updateBilling);

            if (result != null)
            {
                return BadRequest(result);
            }

            return Ok("Payment status updated successfully.");
        }
    }
}
