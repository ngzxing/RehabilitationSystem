using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.AppUser;
using RehabilitationSystem.ViewModels.Report;
using RehabilitationSystem.ViewModels.Session;

namespace RehabilitationSystem.ViewModels.Therapist
{
    public class GetTherapist
    {
        [Required]
        public string? TherapistId { get; set; }
        [Required]
        public string? Name { get; set; }
        public GetAppUser? AppUser {get; set;}
        public ICollection<GetSession>? Sessions { get; set; }
        public ICollection<GetReport>? Reports { get; set; }
    }
}