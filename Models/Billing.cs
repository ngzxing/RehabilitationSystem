using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Models
{
    public class Billing
    {   
        [Key]
        public string? BillingId { get; set; }
        [Required]
        public DateTime? IssueDate { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid total amount")]
        [DataType(DataType.Currency)]
        public decimal? TotalPayAmount { get; set; }

        [Required]
        public bool? PaymentStatus { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? PaymentId { get; set; }


        [ForeignKey("ProgramStudent")]
        [Required]
        public string? ProgramStudentId { get; set; }
        public ProgramStudent? ProgramStudent { get; set; }
        public ICollection<BillingItem>? BillingItems { get; set; }
        
    }
}