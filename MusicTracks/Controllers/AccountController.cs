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
                model.PasswordHash = model.Password.GetHashCode().ToString();

                var user = new UserIdentity
                {
                    UserName = model.UserName,
                    Name = model.Name,
                    Password = model.Password,
                    Surname = model.Surname,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    PasswordHash = model.PasswordHash,
                    Id = model.Id
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                user.SecurityStamp = Guid.NewGuid().ToString();
                await _signManager.SignInAsync(user, true);

                _context.Identities.Add(model);
                _context.SaveChanges();
                return View("/Views/Home/Index.cshtml");
            }
            else
            {
                throw new Exception("Error registration");
            }
        }
    }
}