using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.Announcement
{
    public class AddAnnouncement
    {
        
        
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
        [ValidateNever]
        public DateTime? Date { get; set; }
        
    }
}