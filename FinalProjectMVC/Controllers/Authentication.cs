using FinalProjectMVC.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace FinalProjectMVC.Controllers
{
    public class Authentication : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        public Authentication(SignInManager<User> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            LoginModel log = new(_signInManager, _logger);
            return View("~/Areas/Identity/Pages/Account/login.cshtml", log);
        }
    }
}
