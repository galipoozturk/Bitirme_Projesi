using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTierSample.BLL.Abstract;
using NTierSample.Model.Entities;
using NTierSample.MVC.Models;
using System.Diagnostics;

namespace NTierSample.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserBLL _userService;
        private ITokenService _tokenService;

        public HomeController(ILogger<HomeController> logger, IUserBLL userBLL, ITokenService tokenService)
        {
            _logger = logger;
            _userService = userBLL;
            _tokenService = tokenService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IActionResult Login(User userModel)
        {
            if (string.IsNullOrEmpty(userModel.Email) || string.IsNullOrEmpty(userModel.Password))
            {
                return (RedirectToAction("Login"));
            }
            IActionResult response = Unauthorized();
            var validUser = _userService.GetUserByLoginData(userModel.Email, userModel.Password);

            if (validUser != null)
            {
                string token = _tokenService.BuildToken(validUser);
                if (token != null)
                {
                    //HttpContext.User.IsInRole("Admin")
                    HttpContext.Session.SetString("Token", token);
                    return RedirectToAction("Index","ShoppingLists", new { area = "" });
                }
                else
                {
                    return (RedirectToAction("Error"));
                }
            }
            else
            {
                return (RedirectToAction("Error"));
            }
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