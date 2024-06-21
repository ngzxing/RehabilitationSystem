using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Services;
using RehabilitationSystem.ViewModels.Billing;

namespace RehabilitationSystem.Interfaces
{
    public interface IStripeService
    {
        public Task<StripeReturn> ConfirmPaymentAsync(String paymentMethodId, String paymentIntentId);
        // public Task<StripeReturn> CreatePaymentMethodAsync( PaymentMethod request);
        public Task<StripeReturn> CreatePaymentIntentAsync(int amount);
        public byte[]? GeneratePdfReceipt(GetBilling billing);

         public string GenerateHtmlContent(GetBilling billing);

    }
}