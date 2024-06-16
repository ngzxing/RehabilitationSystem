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
using RehabilitationSystem.Extensions;

namespace RehabilitationSystem.Areas.Therapist.Controllers
{
	[Area("Therapist")]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ISlotRepository _slotRepo;
		private readonly IExtendUserRepository _extendUserRepo;

		public HomeController(ILogger<HomeController> logger, ISlotRepository slotRepo, IExtendUserRepository extendUserRepo)
		{
			_logger = logger;
			_slotRepo = slotRepo;
			_extendUserRepo = extendUserRepo;
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

        public async Task<IActionResult> Dashboard()
        {
            var (user, err_msg) = await User.GetCurrentUserId(_extendUserRepo);

            if (user != null)
            {
                Console.WriteLine(user.AppUserId);
                Console.WriteLine(user.ExtendUserId);
            }
            else
            {
                Console.WriteLine($"Error: {err_msg}");
            }

			ViewData["TherapistId"] = user.ExtendUserId;

			return View();
        }

		[HttpGet]
		public async Task<JsonResult> GetEvents()
		{
			var (user, err_msg) = await User.GetCurrentUserId(_extendUserRepo);

			QuerySlot query = new QuerySlot() { TherapistId = user.ExtendUserId };

			List<string> includes = new List<string> { "TherapistSession", "ProgramStudentSlots" };

			var events = await _slotRepo.GetAllAsync(query, includes);

			return Json(events);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
