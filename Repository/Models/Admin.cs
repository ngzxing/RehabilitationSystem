using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Models
{
    public class Admin
    {
        [Key]
        public string? AdminId { get; set; }
        
        [Required]
        public string? Name { get; set; }

        [ForeignKey("AppUser")]
        [Required]
        public string? AppUserId {get; set;}

        public AppUser? AppUser {get; set;}

        public ICollection<Announcement>? Announcements {get; set;}
    }
}