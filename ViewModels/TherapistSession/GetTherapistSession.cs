using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.Session;
using RehabilitationSystem.ViewModels.Slot;
using RehabilitationSystem.ViewModels.Therapist;

namespace RehabilitationSystem.ViewModels.TherapistSession
{
    public class GetTherapistSession
    {
        
        public string? TherapistSessionId {get; set;}
        public string? TherapistId {get; set;}
        public GetTherapist? Therapist {get; set;}
        public string? SessionId {get; set;}
        public GetSession? Session {get; set;}
        public ICollection<GetSlot>? Slots {get; set;} 
    }
}