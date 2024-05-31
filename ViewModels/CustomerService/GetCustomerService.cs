using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.AppUser;

namespace RehabilitationSystem.ViewModels.CustomerService
{
    public class GetCustomerService
    {
        [Required]
        public string? CustomerServiceId { get; set; }
        [Required]
        public string? Name { get; set; }
        public GetAppUser? AppUser {get; set;}
        
    }
}