using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class accountController : Controller
    {

        private SignInManager<AppUser> SignInMgr { get; set; }

        private UserManager<AppUser> UserMgr { get; set; }
       public accountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }

        public async Task<IActionResult> Login()
        {

            var result = await SignInMgr.PasswordSignInAsync("TestUser", "test123", false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Result = "result is: " + result.ToString();
            }



            return View();
        }

        public async Task<IActionResult> Register( string uname, string psw, string email)
        {

            try
            {
                ViewBag.Message = "User already exists";

                AppUser user = await UserMgr.FindByNameAsync(uname);
                if (user == null)
                {
                    user = new AppUser();
                    user.UserName = uname;
                    user.Email = email;
                    user.FirstName = "John";
                    user.LastName = "Doe'";

                    IdentityResult result = await UserMgr.CreateAsync(user, psw);
                    ViewBag.Message = "UserWas created";
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }



            return View();
        }

        public  IActionResult RegisterPage()
        {


            return View();
        }
    }
}