using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicTracks.Models;

namespace MusicTracks.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<UserIdentity> _signManager;
        private UserManager<UserIdentity> _userManager;
        private MusicTracksContext _context;

        public AccountController(SignInManager<UserIdentity> signManager, UserManager<UserIdentity> userManager, MusicTracksContext context)
        {
            _signManager = signManager;
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserIdentity model)
        {
            if (ModelState.IsValid)
            {
                System.Security.Principal.GenericIdentity identity = new System.Security.Principal.GenericIdentity(string.Empty);

                model.Id = Guid.NewGuid().ToString();
                //model.PasswordHash = model.Password.GetHashCode().ToString();

                var user = new UserIdentity
                {
                    UserName = model.UserName,
                    Name = model.Name,
                    Password = model.Password,
                    Surname = model.Surname,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Id = model.Id
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                user.SecurityStamp = Guid.NewGuid().ToString();
                await _signManager.PasswordSignInAsync(user, user.Password, true, true);

                //_context.Identities.Add(model);
                //_context.SaveChanges();
                return View("/Views/Home/Index.cshtml");
            }
            else
            {
                throw new Exception("Error registration");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return View("/Views/Home/Index.cshtml");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signManager.PasswordSignInAsync(model.Username,
                   model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }

    }
}