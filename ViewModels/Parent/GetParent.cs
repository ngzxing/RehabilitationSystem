using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.AppUser;
using RehabilitationSystem.ViewModels.Student;

namespace RehabilitationSystem.ViewModels.Parent
{
    public class GetParent
    {
        
        public string? ParentId { get; set; } 
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Postcode { get; set; }
        public string? State { get; set; }
        public string? Address { get; set; }
        public string? Occupation { get; set; }
        public string? AppUserId {get; set;}
        public GetAppUser? AppUser {get; set;}
        public ICollection<GetStudent>? Students {get; set;}
    }
}