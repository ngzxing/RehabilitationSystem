using Microsoft.AspNetCore.Mvc;
using RehabilitationSystem.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.Slot;

namespace RehabilitationSystem.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ISlotRepository _slotRepo;

		public HomeController(ILogger<HomeController> logger, ISlotRepository slotRepo)
		{
			_logger = logger;
			_slotRepo = slotRepo;
		}

		public IActionResult Index()
		{
			var userName = User.Identity.Name; // Get the user's username
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get the user's ID
			var userRoles = User.FindAll(ClaimTypes.Role).Select(r => r.Value); // Get the user's roles

			ViewBag.UserName = userName;
			ViewBag.UserId = userId;
			ViewBag.UserRoles = userRoles;

			Console.WriteLine("Start");
			Console.WriteLine(userName);
			Console.WriteLine(userId);
			Console.WriteLine("End");

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

        public IActionResult Dashboard()
        {
            return View();
        }

		public IActionResult Testing()
		{
			return View();
		}

		public IActionResult Calendar()
		{
			return View();
		}

		[HttpGet]
		public async Task<JsonResult> GetEvents()
		{
			QuerySlot query = new QuerySlot();
			List<string> includes = new List<string> { "TherapistSession", "ProgramStudentSlots" };

			var events = await _slotRepo.GetAllAsync(query, includes);
			foreach (var eventItem in events)
			{
				Console.WriteLine($"SlotId: {eventItem.SlotId}");
				Console.WriteLine($"TherapistSessionId: {eventItem.TherapistSession.TherapistSessionId}");
				Console.WriteLine($"StartTime: {eventItem.StartTime}");
				Console.WriteLine($"EndTime: {eventItem.EndTime}");
				Console.WriteLine("------");
			}

			return Json(events);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
