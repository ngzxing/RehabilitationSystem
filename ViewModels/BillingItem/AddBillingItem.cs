using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.BillingItem
{
    public class AddBillingItem
    {

        [Required]
        public string? Description { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid amount")]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        [Required]
        public int? Amount {get; set;}
        [Required]
        public string? BillingId { get; set; }

    }
}