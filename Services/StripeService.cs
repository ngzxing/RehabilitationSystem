using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RehabilitationSystem.Interfaces;
using Stripe;
using System.ComponentModel.DataAnnotations;
using DinkToPdf;
using DinkToPdf.Contracts;
using System.Text;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.Billing;
using System;

namespace RehabilitationSystem.Services
{
    public class StripeService : IStripeService
    {
        private readonly StripeSettings _stripeSettings;
        private readonly IConverter _converter;

        public StripeService(IOptions<StripeSettings> stripeSettings, IConverter converter)
        {
            _stripeSettings = stripeSettings.Value;
            _converter = converter;
    
        }

        public async Task<StripeReturn> CreatePaymentIntentAsync(int amount)
        {
            try
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = amount,
                    Currency = "myr",
                    AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                    {
                    Enabled = true,
                    },
                };

                var paymentIntentService = new PaymentIntentService();
                var paymentIntent = await paymentIntentService.CreateAsync(options);

                return new StripeReturn{ Id = paymentIntent.ClientSecret};
            }
            catch (Exception ex)
            {
                return new StripeReturn{ Error = "Create Payment Intent Fail: " + ex.Message };
            }
        }

        

        public async Task<StripeReturn> ConfirmPaymentAsync(String paymentMethodId, String paymentIntentId)
        {
                try
                {
                    var paymentIntentService = new PaymentIntentService();
                    var confirmOptions = new PaymentIntentConfirmOptions
                    {
                        PaymentMethod = paymentMethodId,
                    };

                    var confirmedPaymentIntent = await paymentIntentService.ConfirmAsync(paymentIntentId, confirmOptions);


                    if (confirmedPaymentIntent.Status == "succeeded")
                    {
                        return new StripeReturn{ Id = confirmedPaymentIntent.Id };
                    }
                    else
                    {
                        return new StripeReturn{ Error = "Payment Fail: " + confirmedPaymentIntent.Status };
                    }
                }
                catch (Exception ex)
                {
                    return new StripeReturn{ Error = ex.Message };
                }
        }

        public byte[]? GeneratePdfReceipt(GetBilling billing)
        {
            try
            {
                
                
                var doc = new HtmlToPdfDocument()
                {
                    GlobalSettings = new GlobalSettings
                    {
                        ColorMode = ColorMode.Color,
                        Orientation = Orientation.Portrait,
                        PaperSize = PaperKind.A4,
                        Margins = new MarginSettings { Top = 10 }
                    },
                    Objects = {
                        new ObjectSettings
                        {
                            PagesCount = true,
                            HtmlContent = GenerateHtmlContent(billing),
                            WebSettings = { DefaultEncoding = "utf-8" },
                            HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                            FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Receipt" }
                        }
                    }
                };

               
                var docs = _converter.Convert(doc);
                
                return docs;

            }
            catch (Exception ex)
            {   
                Console.WriteLine(ex);
                return null;
            }
        }


        public string GenerateHtmlContent(GetBilling billing)
        {   
            Console.WriteLine("\n\n\n\nGenrating html\n\n\n\n\n\n");
            var html = new StringBuilder();
            html.Append("<html><head><style>table { width: 100%; border-collapse: collapse; } th, td { border: 1px solid black; padding: 8px; text-align: left; } </style></head><body>");
            html.Append("<h1>Receipt</h1>");
            html.Append($"<p>Billing ID: {billing.BillingId}</p>");
            html.Append($"<p>Billing Issue Date: {billing.IssueDate}</p>");
            html.Append($"<p>Pay Date: {billing.PaymentDate}</p>");
            html.Append($"<p>Parent Name: {billing.ParentName}      Parent Id : {billing.ParentId}</p>");
            html.Append($"<p>Student Name: {billing.StudentName}      Student Id : {billing.StudentId}</p>");
            html.Append("<table><thead><tr><th>Description</th><th>Amount (RM)</th></tr></thead><tbody>");

            foreach (var lineItem in billing.BillingItems!)
            {
                html.Append("<tr>");
                html.Append($"<td>{lineItem.Description}</td>");
                html.Append($"<td>{lineItem.Amount}</td>");
                html.Append("</tr>");
            }
            
            html.Append("<tr>");
            html.Append($"<td>{billing.ProgramName}</td>");
            html.Append($"<td>{billing.ProgramPrice}</td>");
            html.Append("</tr>");

            html.Append("</tbody></table>");
            html.Append($"<p>Total: RM {billing.TotalPayAmount:C}</p>");
            html.Append("</body></html>");
            
            Console.WriteLine("\n\n\n\nFinish Genrating html\n\n\n\n\n\n");
            return html.ToString();
        }


    }  

    public class PaymentMethod
    {   
        [Required]
        public string? paymentMethodId {get; set;}
        [Required]
        public string? BillingId { get; set; }
    }


    public class StripeSettings
    {
        public required string PublishableKey { get; set; }
        public required string SecretKey { get; set; }
    }

    public class StripeReturn{

        public string? Id {get; set;}
        public string? Error {get; set;}
    }

    
}
