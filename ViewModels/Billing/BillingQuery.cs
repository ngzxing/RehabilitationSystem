using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.Billing
{
    public class BillingQuery
    {
        public DateTime? IssueDateBefore { get; set; }
        public DateTime? IssueDateAfter { get; set; }
        public decimal? LessThanTotalPayAmount { get; set; }
        public decimal? MoreThanTotalPayAmount { get; set; }
        public bool? PaymentStatus { get; set; }
        public DateTime? PaymentDateBefore { get; set; }
        public DateTime? PaymentDateAfter { get; set; }
        public string? StudentId { get; set; }
        public string? ParentId { get; set; }
        public string? ProgramName { get; set; }
        public int? PageNumber {get; set;}
        public int? PageSize {get; set;}
    }
}