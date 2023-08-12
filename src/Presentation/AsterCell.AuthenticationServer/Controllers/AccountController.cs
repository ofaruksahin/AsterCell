using AsterCell.AuthenticationServer.Constants;
using AsterCell.AuthenticationServer.Domain.Entities;
using AsterCell.AuthenticationServer.Extensions;
using AsterCell.AuthenticationServer.ViewModels;
using IdentityServer4.Events;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AsterCell.AuthenticationServer.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IEventService _eventService;
        private readonly SignInManager<AsterCellUser> _signInManager;

        public AccountController(
             IEventService eventService,
            SignInManager<AsterCellUser> signInManager
           )
        {
            _eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var vm = new LoginViewModel(returnUrl);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);


            var user = await _signInManager.UserManager.FindByEmailAsync(vm.Email);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, Messages.InvalidUsernameOrPassword);
                return View(vm);
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, vm.Password, vm.RememberLogin, false);

            if (!signInResult.Succeeded)
            {
                await _eventService.RaiseAsync(new UserLoginFailureEvent(vm.Email, Messages.InvalidUsernameOrPassword));
                ModelState.AddModelError(string.Empty, Messages.InvalidUsernameOrPassword);
                return View(vm);
            }

            await _eventService.RaiseAsync(new UserLoginSuccessEvent(user.Email, user.Id.ToString(), user.Email));

            if (Url.IsLocalUrl(vm.ReturnUrl))
            {
                return Redirect(vm.ReturnUrl);
            }
            else if (string.IsNullOrEmpty(vm.ReturnUrl))
            {
                return Redirect("~/");
            }

            return Redirect(vm.ReturnUrl);
        }

        [HttpGet]
        public IActionResult Redirect(RedirectViewModel vm)
        {
            return View(vm);
        }
    }
}
