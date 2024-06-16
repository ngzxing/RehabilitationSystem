using Microsoft.AspNetCore.Mvc;
using RehabilitationSystem.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace RehabilitationSystem.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
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
			Console.WriteLine(userRoles);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
