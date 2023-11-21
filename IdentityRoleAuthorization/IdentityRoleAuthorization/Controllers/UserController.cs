using Ecommerce.Model.Models.Dtos;
using Ecommerce.Service.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> AllUsers()
        {
            var users = await _userService.GetAllUsers();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUserRequestDto userDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateUserAsync(userDto);

                if (result.Succeeded)
                {
                    return RedirectToAction("AllUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(userDto);
        }

        public async Task<IActionResult> Details(string userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return RedirectToAction("AllUsers");
            }

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return RedirectToAction("AllUsers");
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, ApplicationUserResponseDto updatedUserDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UpdateUserAsync(userId, updatedUserDto);

                if (result.Succeeded)
                {
                    return RedirectToAction("AllUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(updatedUserDto);
        }

        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(string userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return RedirectToAction("AllUsers");
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string userId)
        {
            var result = await _userService.DeleteUserAsync(userId);

            if (result.Succeeded)
            {
                return RedirectToAction("AllUsers");
            }

            var user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return RedirectToAction("AllUsers");
            }

            ModelState.AddModelError(string.Empty, "Failed to delete the user.");

            return View("DeleteConfirmation", user);
        }

    }
}