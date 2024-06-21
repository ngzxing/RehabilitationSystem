using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Models
{
    public class BillingItem
    {   
        [Key]
        public string? BillingItemId { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid amount")]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        [Required]
        public int? Amount {get; set;}

        [ForeignKey("Billing")]
        public string? BillingId { get; set; }
        public Billing? Billing { get; set; }
    }
}