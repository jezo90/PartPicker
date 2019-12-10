using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PartPicker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static PartPicker.Models.IdentityModels;

namespace PartPicker.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;


            return View();
        }

        [HttpPost] // USTAWIENIE METODY
        [ValidateAntiForgeryToken] // DODATKOWE ZABEZPIECZENIE
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) // SPRAWDZENIE CZY FORMULARZ ZOSTAŁ POPRAWNIE WYPEŁNIONY
            {
                return View(model);  // ZWRÓCENIE FORMULARZA
            }

            ApplicationUser signedUser = UserManager.FindByEmail(model.Email);
            SignInStatus result;
            if (signedUser != null)
            {
                result = await SignInManager.PasswordSignInAsync(signedUser.UserName, model.Password,
                    model.RememberMe, shouldLockout: false);
            }
            else
            {
                result = SignInStatus.Failure;
            }

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);  // LOGOWANIE POMYŚLNE 
                default:
                    ModelState.AddModelError("Summary", "Nieprawidłowy email lub hasło.");
                    return View(model);                 // LOGOWANIE NIEPOMYŚLNE
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost] // USTAWIENIE METODY
        [AllowAnonymous] // DODATKOWE ZABEZPIECZENIE 
        [ValidateAntiForgeryToken] // DODATKOWE ZABEZPIECZENIE
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) // SPRAWDZENIE CZY FORMULARZ ZOSTAŁ POPRAWNIE WYPEŁNIONY
            {
                var user = new ApplicationUser { UserName = model.UserName,
                                                Email = model.Email, Permission = "user" };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("Summary", "Email lub login jest już w użyciu");
                AddErrors(result);
            }
            return View(model);     // ZWRÓCENIE FORMULARZA
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

    }
}