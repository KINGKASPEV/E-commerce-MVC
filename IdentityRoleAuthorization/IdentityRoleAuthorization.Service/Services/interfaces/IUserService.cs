using Ecommerce.Model.Models.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Service.Services.interfaces
{
	public interface IUserService
	{
		Task<IdentityResult> CreateUserAsync(ApplicationUserRequestDto userDto);
		Task<ApplicationUserResponseDto> GetUserByIdAsync(string userId);
		Task<IdentityResult> UpdateUserAsync(string UserId, ApplicationUserResponseDto updatedUserDto);
		Task<IdentityResult> DeleteUserAsync(string userId);
		Task<IEnumerable<ApplicationUserResponseDto>> GetAllUsers();
	}
}
