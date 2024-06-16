using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Repository;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.Slot;
using RehabilitationSystem.ViewModels.Session;
using RehabilitationSystem.ViewModels.TherapistSession;


namespace RehabilitationSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlotController : Controller
    {
        private readonly ISlotRepository _slotRepo;
        private readonly ISessionRepository _sessionRepo;
        private readonly ITherapistSessionRepository _therapistSessionRepo;

        public SlotController(ISlotRepository slotRepo, ISessionRepository sessionRepo, ITherapistSessionRepository therapistSessionRepo)
        {
            _slotRepo = slotRepo;
            _sessionRepo = sessionRepo;
            _therapistSessionRepo = therapistSessionRepo;
        }

/*        [HttpGet]
        public async Task<IActionResult> GetSlotsBySessionId(string sessionId)
        {
            List<string> includes = new List<string>() { "Slots" };
            GetSession sessionVM = await _sessionRepo.GetByIdAsync(sessionId, includes);
            foreach (var slots in sessionVM.Slots)
                Console.WriteLine(slots.SlotId);
            return Json(sessionVM.Slots);
        }*/

        [HttpGet]
        public async Task<IActionResult> GetSlotsBySessionId(string sessionId)
        {
            List<string> includes = new List<string>() { "Slots", "Therapists" };
            GetSession sessionVM = await _sessionRepo.GetByIdAsync(sessionId, includes);
            foreach (var slots in sessionVM.Slots)
                Console.WriteLine(slots.SlotId);
            return Json(sessionVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddSlot([FromBody] SlotDto data)
        {
            Console.WriteLine(data.TherapistId);
            if (data == null)
            {
                return BadRequest(new { message = "Invalid data." });
            }

            try
            {
                // Validate data if necessary
                if (string.IsNullOrEmpty(data.SessionId) || string.IsNullOrEmpty(data.TherapistId) || data.StartTime >= data.EndTime)
                {
                    return BadRequest(new { message = "Invalid data." });
                }

                GetTherapistSession therapistSession = await _therapistSessionRepo.GetByTherapistSessionIdAsync(data.TherapistId, data.SessionId, new List<string>());

                // Map to Slot entity
                AddSlot slot = new AddSlot
                {
                    StartTime = data.StartTime,
                    EndTime = data.EndTime,
                    TherapistSessionId = therapistSession.TherapistSessionId
                };

                var result = await _slotRepo.AddAsync(slot);

                return Ok(new { message = "Slot added successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding the slot.", error = ex.Message });
            }
        }

        [HttpPut("Admin/Slot/UpdateSlot/{slotId}")]
        public async Task<IActionResult> UpdateSlot( [FromRoute] string slotId, [FromBody] UpdateSlot data)
        {
            Console.WriteLine("Masuk");
            if (data == null)
            {
                return BadRequest(new { message = "Invalid data." });
            }

            try
            {
                var result = await _slotRepo.UpdateAsync(slotId, data);

                return Ok(new { message = "Slot update successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding the slot.", error = ex.Message });
            }
        }

        // POST: ProgramController/Delete/5
        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var result = await _slotRepo.DeleteAsync(id);
                Console.WriteLine(id + "HAHA");
                if (result == null)
                {
                    return Json(new { success = true, message = "Program deleted successfully." });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while deleting the program." });
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
