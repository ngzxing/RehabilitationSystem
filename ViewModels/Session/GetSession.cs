using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.Slot;
using RehabilitationSystem.ViewModels.Therapist;

namespace RehabilitationSystem.ViewModels.Session
{
    public class GetSession
    {
        
        public string? SessionId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<GetSlot>? Slots { get; set; }
        public ICollection<GetTherapist>? Therapists { get; set; }
    }
}