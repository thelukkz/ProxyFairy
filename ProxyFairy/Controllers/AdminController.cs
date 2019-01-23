using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProxyFairy.Core.Model;
using ProxyFairy.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProxyFairy.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private UserManager<AppUser> _userManager;
        private IUserValidator<AppUser> _userValidator;
        private IPasswordValidator<AppUser> _passwordValidator;
        private IPasswordHasher<AppUser> _passwordHasher;

        public AdminController(UserManager<AppUser> userManager,
            IUserValidator<AppUser> userValidator,
            IPasswordValidator<AppUser> passwordValidator,
            IPasswordHasher<AppUser> passwordHasher)
        {
            _userManager = userManager;
            _userValidator = userValidator;
            _passwordValidator = passwordValidator;
            _passwordHasher = passwordHasher;
        }
        public ViewResult Index() => View();

        #region USERS

        public ViewResult Users() => View(_userManager.Users);

        public ViewResult CreateUser() => View();

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Users");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded) return RedirectToAction("Users");
                else AddErrorsFromResult(result);
            }
            else
            {
                ModelState.AddModelError("", "User not found");
            }
            return View("Users");
        }

        public async Task<IActionResult> EditUser(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null) return View(user);
            else return RedirectToAction("Users");
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string id, string email, string password)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;
                IdentityResult validateEmail = await _userValidator.ValidateAsync(_userManager, user);
                if (!validateEmail.Succeeded) AddErrorsFromResult(validateEmail);

                IdentityResult validatePassword = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validatePassword = await _passwordValidator.ValidateAsync(_userManager, user, password);
                    if (validatePassword.Succeeded) user.PasswordHash = _passwordHasher.HashPassword(user, password);
                    else AddErrorsFromResult(validatePassword);
                }

                if ((validateEmail.Succeeded && validatePassword == null)
                    || (validateEmail.Succeeded && password != string.Empty && validatePassword.Succeeded))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded) return RedirectToAction("Users");
                    else AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User not found");
            }
            return View(user);
        }

        #endregion

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}
