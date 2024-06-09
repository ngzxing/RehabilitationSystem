using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RehabilitationSystem.Models
{
    public class AppUser : IdentityUser
    {
        public Admin? Admin { get; set; }
        public Therapist? Therapist { get; set; }
        public CustomerService? CustomerService { get; set; }
        public Parent? Parent { get; set; }
    }
}