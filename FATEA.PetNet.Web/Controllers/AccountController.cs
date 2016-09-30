using FATEA.PetNet.Web.Indentity;
using FATEA.PetNet.Web.ViewModels.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace FATEA.PetNet.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private static RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(new PetNetIdentityDbContext());
        private static RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);

        private static UserStore<IdentityUser> userStore = new UserStore<IdentityUser>(new PetNetIdentityDbContext());
        private static UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(userStore);

        public ActionResult CreateUser()
        {
            
            ViewBag.Roles = new SelectList(roleManager.Roles, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Createuser(UserEditViewModel viewModel)
        {
            ViewBag.Roles = new SelectList(roleManager.Roles, "Id", "Name");
            if (!ModelState.IsValid)
            {
                
                return View(viewModel);
            }
                        
            IdentityUser user = new IdentityUser
            {
                UserName = viewModel.UserName,
                Email = viewModel.UserName
            };

            IdentityResult result = userManager.Create(user, viewModel.Password);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("indentity_error", result.Errors.First());
                return View(viewModel);
            }

            IdentityRole selectedRole = roleManager.Roles.Single(s => s.Id == viewModel.RoleId);
            IdentityUser insertedUser = userManager.Find(viewModel.UserName, viewModel.Password);
            userManager.AddToRole(insertedUser.Id, selectedRole.Name);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Login(UserLoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>(new PetNetIdentityDbContext());
            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(userStore);

            IdentityUser user = userManager.Find(viewModel.UserName, viewModel.Password);

            if (user == null)
            {
                ModelState.AddModelError("indentity_error", "Nome de usuário ou senha incorretos.");
                return View(viewModel);
            }

            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            ClaimsIdentity userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

            authManager.SignIn(userIdentity);
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Logout()
        {
            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Login", "Account");          
        }
    }
}