using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.Therapist;


namespace RehabilitationSystem.ViewModels.TherapistSession
{
    public class SelectTherapistSession
    {
        public GetTherapistSession? TherapistSession { get; set; }
        public ICollection<GetTherapist>? Therapists { get; set; }
    }
}
