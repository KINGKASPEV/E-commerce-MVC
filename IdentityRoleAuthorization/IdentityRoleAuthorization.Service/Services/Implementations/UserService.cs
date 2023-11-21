using Ecommerce.Model.Models.Dtos;
using Ecommerce.Service.Services.interfaces;
using IdentityRoleAuthorization.Constants;
using IdentityRoleAuthorization.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Service.Services.Implementations
{
	public class UserService : IUserService
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public UserService(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IdentityResult> CreateUserAsync(ApplicationUserRequestDto userDto)
		{
			var user = new ApplicationUser
			{
				UserName = userDto.Email,
				Email = userDto.Email,
				PhoneNumber = userDto.PhoneNumber,
				Name = userDto.Name,
				ProfileProfile = userDto.ProfileProfile
			};

			var result = await _userManager.CreateAsync(user, userDto.Password);

			if (result.Succeeded)
			{
				await _userManager.AddToRoleAsync(user, Roles.User.ToString());
			}

			return result;
		}

		public async Task<ApplicationUserResponseDto> GetUserByIdAsync(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);

			if (user == null)
			{
				return null;
			}

			var userDto = new ApplicationUserResponseDto
			{
				Id = user.Id,
				Name = user.Name,
				Email = user.Email,
				PhoneNumber = user.PhoneNumber,
				ProfileProfile = user.ProfileProfile
			};

			return userDto;
		}

		public async Task<IdentityResult> UpdateUserAsync(string userId, ApplicationUserResponseDto updatedUserDto)
		{
			var user = await _userManager.FindByIdAsync(updatedUserDto.Id);

			if (user == null)
			{
				return IdentityResult.Failed(); 
			}

			user.Name = updatedUserDto.Name;
			user.Email = updatedUserDto.Email;
			user.PhoneNumber = updatedUserDto.PhoneNumber;
			user.ProfileProfile = updatedUserDto.ProfileProfile;

			var result = await _userManager.UpdateAsync(user);
			return result;
		}

		public async Task<IdentityResult> DeleteUserAsync(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);

			if (user == null)
			{
				return IdentityResult.Failed();
			}

			var result = await _userManager.DeleteAsync(user);
			return result;
		}

		public async Task<IEnumerable<ApplicationUserResponseDto>> GetAllUsers()
		{
			var users = await _userManager.Users
				.Select(user => new ApplicationUserResponseDto
				{
					Id = user.Id,
					Name = user.Name,
					Email = user.Email,
					PhoneNumber = user.PhoneNumber,
					ProfileProfile = user.ProfileProfile
				})
				.ToListAsync(); 

			return users;
		}


	}
}
