using AsterCell.AuthenticationServer.Constants;
using AsterCell.AuthenticationServer.Domain.Entities;
using AsterCell.AuthenticationServer.Extensions;
using AsterCell.AuthenticationServer.ViewModels;
using IdentityServer4.Events;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AsterCell.AuthenticationServer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly SignInManager<AsterCellUser> _signInManager;

        public AccountController(
             IEventService eventService,
            IIdentityServerInteractionService interaction,
            SignInManager<AsterCellUser> signInManager
           )
        {
            _eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _interaction = interaction ?? throw new ArgumentNullException(nameof(interaction));
        }

        [HttpGet]
        public IActionResult LogIn(string returnUrl)
        {
            var vm = new LoginViewModel(returnUrl);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var context = await _interaction.GetAuthorizationContextAsync(vm.ReturnUrl);

            var user = await _signInManager.UserManager.FindByEmailAsync(vm.Email);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, Messages.InvalidUsernameOrPassword);
                return View(vm);
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, vm.Password, vm.RememberLogin, false);

            if (!signInResult.Succeeded)
            {
                await _eventService.RaiseAsync(new UserLoginFailureEvent(vm.Email, Messages.InvalidUsernameOrPassword, clientId: context?.Client.ClientId));
                ModelState.AddModelError(string.Empty, Messages.InvalidUsernameOrPassword);
                return View(vm);
            }

            if (context != null)
            {
                if (context.IsNativeClient())
                {
                    return this.LoadingPage("Redirect", vm.ReturnUrl);
                }

                return Redirect(vm.ReturnUrl);
            }

            if (Url.IsLocalUrl(vm.ReturnUrl))
            {
                return Redirect(vm.ReturnUrl);
            }
            else if (string.IsNullOrEmpty(vm.ReturnUrl))
            {
                return Redirect("~/");
            }else
            {
                ModelState.AddModelError(string.Empty, Messages.InvalidUsernameOrPassword);
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Redirect(RedirectViewModel vm)
        {
            return View(vm);
        }
    }
}
