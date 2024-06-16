using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Repository;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.TherapistSession;

namespace RehabilitationSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TherapistSessionController : Controller
    {
        private readonly ITherapistSessionRepository _therapistSessionRepo;

        public TherapistSessionController(ITherapistSessionRepository therapistSessionRepo)
        {
            _therapistSessionRepo = therapistSessionRepo;
        }

        [HttpPost]
        public async Task<IActionResult> AddTherapistSession([FromBody] AddTherapistSession data)
        {
            if (data == null)
            {
                return BadRequest(new { message = "Invalid data." });
            }

            try
            {
                GetTherapistSession therapistSession = await _therapistSessionRepo.GetByTherapistSessionIdAsync(data.TherapistId, data.SessionId, new List<string>());

                if (therapistSession != null)
                    return BadRequest(new { message = "The therapist already assigned to current session." });

                var result = await _therapistSessionRepo.AddAsync(data);
                return Ok(new { message = "TherapistSession added successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding the TherapistSession.", error = ex.Message });
            }
        }

        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> Delete(string sessionId, string therapistId)
        {
            try
            {
                GetTherapistSession therapistSession = await _therapistSessionRepo.GetByTherapistSessionIdAsync(therapistId, sessionId, new List<string>());

                if (therapistSession == null)
                    return BadRequest(new { message = "The therapistSession not found." });

                var result = await _therapistSessionRepo.DeleteAsync(therapistSession.TherapistSessionId);
                if (result == null)
                {
                    return Json(new { success = true, message = "TherapistSession deleted successfully." });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while deleting the TherapistSession." });
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
