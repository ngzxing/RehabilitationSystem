using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Repository;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.TherapistSession;
using RehabilitationSystem.ViewModels.Therapist;

namespace RehabilitationSystem.Controllers
{
    public class TherapistController : Controller
    {
        private readonly ITherapistSessionRepository _therapistSessionRepo;
        private readonly ITherapistRepository _therapistRepo;

        public TherapistController(ITherapistSessionRepository therapistSessionRepo, ITherapistRepository therapistRepo)
        {
            _therapistSessionRepo = therapistSessionRepo;
            _therapistRepo = therapistRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

/*        [HttpGet]
        public async Task<IActionResult> GetTherapists(string sessionId)
        {
*//*            QueryTherapistSession query = new QueryTherapistSession() { SessionId = sessionId };
*//*            List<string> includes = new List<string>() { "Therapist" };
            GetTherapistSession? TherapistSessionVM = await _therapistSessionRepo.GetBySessionIdAsync("aaaaaa", includes);
          


            QueryTherapist query = new QueryTherapist() { };
            List<GetTherapist> TherapistsVM = await _therapistRepo.GetAllAsync(query, new List<string>());

            SelectTherapistSession selectTherapistSessionVM = new SelectTherapistSession()
            {
                TherapistSession = TherapistSessionVM,
                Therapists = TherapistsVM
            };

            return Json(selectTherapistSessionVM);
        }*/

        [HttpGet]
        public async Task<IActionResult> GetTherapists()
        {
            QueryTherapist query = new QueryTherapist() { };
            List<string> includes = new List<string>() { "AppUser" };
            List<GetTherapist> TherapistsVM = await _therapistRepo.GetAllAsync(query, includes);

            return Json(TherapistsVM);
        }
    }
}
