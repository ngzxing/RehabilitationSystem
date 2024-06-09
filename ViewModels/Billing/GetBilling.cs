using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.BillingItem;

namespace RehabilitationSystem.ViewModels.Billing
{
    public class GetBilling
    {
        public string? BillingId { get; set; }
        public DateTime? IssueDate { get; set; }
        public decimal? TotalPayAmount { get; set; }
        public bool? PaymentStatus { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? ProgramName { get; set; }
        public ICollection<GetBillingItem>? BillingItems { get; set; }
        public string? StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? ParentId { get; set; }
        public string? ParentName { get; set; }
        
    }
}