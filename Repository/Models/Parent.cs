using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Models
{
    public class Parent
    {
        [Key]
        public string? ParentId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Postcode { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Occupation { get; set; }

        [ForeignKey("AppUser")]
        [Required]
        public string? AppUserId {get; set;}
        public AppUser? AppUser {get; set;}
        
        public ICollection<Student>? Students {get; set;}
    }
}