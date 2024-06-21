using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.Services;
using RehabilitationSystem.ViewModels.Billing;
using Stripe;

namespace RehabilitationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IStripeService _stripeService;
        private readonly IBillingRepository _billingRepository;

        public PaymentController(IStripeService stripeService, IBillingRepository billingRepository){

            _stripeService = stripeService;
            _billingRepository = billingRepository;

        }



        [HttpGet("pay")]
        public async Task<IActionResult> Pay([FromQuery] string BillingId){

            if(!ModelState.IsValid){
                
                return BadRequest(new {Error = "Invalid Payment"});
            }

            var billing = await _billingRepository.GetByIdAsync(BillingId, []);
            
            if( billing == null){

                return BadRequest(new {Error = "Billing Not Found"});
            }


            var response = await _stripeService.CreatePaymentIntentAsync( (int)(billing!.TotalPayAmount! * 100 ) );

            if(response.Error!= null){

                return BadRequest(new {Error = "Create Payment Intent Failed: " + response.Error} );
            }
            
            

            return Ok(new { clientSecret = response.Id });
        }

        [HttpGet("update-payment")]
        public async Task<IActionResult> UpdatePayment([FromQuery] string billingId, [FromQuery] string payment_intent){
            
            
            var updateError =  await _billingRepository.UpdateAsync( billingId!, new UpdateBilling{ PaymentStatus = true, PaymentId = payment_intent });

            if(updateError != null){

                return BadRequest( new { error = "Update Payment Status Failed: " + updateError} );
            }

            return Ok("Update Payment Success");
        }

        

        [HttpGet("receipt")]
        public async Task<IActionResult> Receipt([FromQuery] string billingId ){
            
            Console.WriteLine($"\n\n\n\n{DateTime.Now}\n\n\n\n");
            if(!ModelState.IsValid){

                return BadRequest("Invalid Request");
            }

            var billing = await _billingRepository.GetByIdAsync(billingId, ["BillingItems"]);
            
            if( billing == null){

                return BadRequest("Billing Not Found");
            }

            var file = _stripeService.GeneratePdfReceipt(billing);
       

            if(file == null){

                return BadRequest("Generate Fail");
            }
            
            
            return File( file,  "application/pdf", "receipt.pdf");
        }
    }


}