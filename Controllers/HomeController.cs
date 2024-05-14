using Ecom_GoruKhasi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Ecom_GoruKhasi.Globals;

namespace Ecom_GoruKhasi.Controllers
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
            return View();
        }


        //About us
        public IActionResult AboutUs()
        {
            return View();
        }


        //Contact us
        public IActionResult Contact()
        {
            return View();
        }

        //Terms and Condition
        public IActionResult TermsAndCondition()
        {
            return View();
        }

        //Login

        public IActionResult Login()
        {
            return View();
        } 

        //Register
        public IActionResult Register()
        {
            return View();
        }
       

        [HttpPost]
        public IActionResult RegisterUser(
             string FullName,
             string Email,
             string PhoneNumber,
             string Password,
             string District,
             string Area
            )
        {

            Create.Register(FullName, Email,PhoneNumber, Password, District, Area);
            return RedirectToAction("Login");
        }

        //Cart

        public IActionResult Cart()
        {
            return View();
        }

        //Checkout

        public IActionResult Checkout()
        {
            return View();
        }

		// Product Details

		public IActionResult ProductDetails()
		{
			return View();
		}

        public IActionResult AllCattle()
        {
            return View();
        }


        public IActionResult AllGoat()
        {
            return View();
        }

        //User Dashboard

        public IActionResult UserProfile()
        {
            return View();
        }
        public IActionResult OrderHistory()
        {
            return View();
        }

        public IActionResult TrackOrder()
        {
            return View();
        }
        public IActionResult Invoice()
        {
            return View();
        }



        public IActionResult Privacy()
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