using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using WebApplication1.Areas.admin.Models;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository.Base;

namespace WebApplication1.Areas.admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            var users = _userManager.Users;
            return View(users);
        }
        //GET
        public IActionResult New()
        {
            return View();

        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(IdentityUser identityUser)
        {
            if (ModelState.IsValid)
            {

                var result = await _userManager.CreateAsync(identityUser);

                if (result.Succeeded)
                {
                    TempData["success"] = "Done";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["success"] = "error";
                    return View(identityUser);
                }
              
            }
            else
            {
                return View(identityUser);
            }
        }

        //GET
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                // User deleted successfully
                return RedirectToAction("Index");
            }
            else
            {
                // Handle error
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("Delete", user);
            }
        }


        //GET
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //post
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(IdentityUser user)
        {

            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByIdAsync(user.Id);

                if (existingUser == null)
                {
                    return NotFound();
                }

                existingUser.UserName = user.UserName;
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.EmailConfirmed = user.EmailConfirmed;

                var result = await _userManager.UpdateAsync(existingUser);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(user);
        }
    }
}
