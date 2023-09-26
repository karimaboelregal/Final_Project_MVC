using E_Commerce.Data.Context;
using FinalProjectMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace FinalProjectMVC.Controllers
{

    public class UserAuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public UserAuthController(DataContext context,
                                  UserManager<User> userManager,
                                  SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [AllowAnonymous]
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            ProductViewModel p = new ProductViewModel();
            p.login = loginModel;


            var result = await _signInManager.PasswordSignInAsync(loginModel.FullName,
                                                                   loginModel.Password,
                                                                        true,
                                                                   lockoutOnFailure: false);




            return PartialView("_UserLoginPartial", p);

        }

        [AllowAnonymous]
        [HttpPost]

        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(RegistrationModel registrationModel)
        {



            User user = new User
            {
                FullName = registrationModel.FullName,
                Email = registrationModel.Email,
                UserName = registrationModel.FullName,




            };

            var result = await _userManager.CreateAsync(user, registrationModel.Password);
            var f = 2;
            ProductViewModel p = new ProductViewModel();
            p.registration = registrationModel;
            if (result.Succeeded)
            {


                await _signInManager.SignInAsync(user, isPersistent: false);

                //if (registrationModel.CategoryId != 0)
                //{
                //    await AddCategoryToUser(user.Id, registrationModel.CategoryId);

                //}

                return PartialView("_UserRegistrationPartial", p);


                //AddErrorsToModelState(result);

            }

            return PartialView("_UserRegistrationPartial", p);

        }

        //[AllowAnonymous]
        //public async Task<bool> UserNameExists(string userName)
        //{
        //    bool userNameExists = await _context.Users.AnyAsync(u => u.UserName.ToUpper() == userName.ToUpper());

        //    if (userNameExists)
        //        return true;

        //    return false;

        //}

        private void AddErrorsToModelState(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }

        //private async Task AddCategoryToUser(string userId, int categoryId)
        //{
        //    UserCategory userCategory = new UserCategory();
        //    userCategory.CategoryId = categoryId;
        //    userCategory.UserId = userId;
        //    _context.UserCategory.Add(userCategory);
        //    await _context.SaveChangesAsync();
        //}
    }
}
