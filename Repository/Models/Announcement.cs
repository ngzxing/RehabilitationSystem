using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Models
{
    public class Announcement
    {   
        [Key]
        public string? AnnouncementId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        [Required]
        public bool? Status { get; set; }
        
        [ForeignKey("Admin")]
        public string? AdminId { get; set; }
        public Admin? Admin { get; set; }
    }
}