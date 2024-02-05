using Microsoft.AspNetCore.Identity;
using StoreApp.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Business.AbstractServices
{
	//TODO: Rollerle ilgili temel crud islemlerini yap.
	public interface IAuthService
	{
		IEnumerable<IdentityRole> Roles { get; }
		IEnumerable<IdentityUser> GetAllUsers();
		Task<IdentityUser> GetOneUserAsync(string userName);//email ya da userName parametre olarak verilebilir
		Task<UserDtoForUpdate> GetOneUserForUpdateAsync(string userName);//UserDtoForUpdate bu sekilde tanimlamamizin sebebi bizim UserDtoForUpdate'deki UserRole'lere ihtiyac duymamiz
		Task<IdentityResult> CreateUserAsync(UserDtoForCreation userDto);
		Task UpdateUserAsync(UserDtoForUpdate userDto);
		Task<IdentityResult> ResetPasswordAsync(ResetPasswordDto model);
		Task<IdentityResult> DeleteUserAsync(string userName);
	}
}
 