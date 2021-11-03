using CorsacTechTask.Models;
using CorsacTechTask.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsacTechTask.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> singInManager;

        
        public AuthController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> singInManager)
        {
            this.userManager = userManager;
            this.singInManager = singInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var idntyRes = await singInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,false);
                if (idntyRes.Succeeded)
                    return RedirectToAction("Index", "Home");
            }
           
                ModelState.AddModelError("", "Username or Password incorrect");
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await singInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName=model.Email,
                    Email=model.Email
                };
               var rslt = await userManager.CreateAsync(user, model.Password);
                if (rslt.Succeeded)
                {
                    await singInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var err in rslt.Errors)
                    ModelState.AddModelError("", err.Description);
            }
            return View(model);
        }


    }
}
