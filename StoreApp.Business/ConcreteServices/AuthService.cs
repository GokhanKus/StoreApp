using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StoreApp.Business.AbstractServices;
using StoreApp.DataAccess.AbstractRepos;
using StoreApp.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Business.ConcreteServices
{
	public class AuthService : IAuthService
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly IMapper _mapper;

		public AuthService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IMapper mapper)
		{
			_roleManager = roleManager;
			_userManager = userManager;
			_mapper = mapper;
		}
		public IEnumerable<IdentityRole> Roles => _roleManager.Roles;

		public async Task<IdentityResult> CreateUserAsync(UserDtoForCreation userDto)
		{
			var user = _mapper.Map<IdentityUser>(userDto);
			var result = await _userManager.CreateAsync(user, userDto.Password);
			if (!result.Succeeded)
				throw new Exception("user could not be created");
			if (userDto.Roles.Count > 0)
			{
				var roleResult = await _userManager.AddToRolesAsync(user, userDto.Roles);
				if (!roleResult.Succeeded)
					throw new Exception("system has problems with roles");
			}
			return result;
		}

		public IEnumerable<IdentityUser> GetAllUsers()
		{
			return _userManager.Users.ToList();
		}

		public async Task<IdentityUser> GetOneUserAsync(string userName)
		{
			return await _userManager.FindByNameAsync(userName);
		}

		public async Task<UserDtoForUpdate> GetOneUserForUpdate(string userName)
		{
			var user = await GetOneUserAsync(userName);
			if (user != null)
			{
				var userDto = _mapper.Map<UserDtoForUpdate>(user); //UserDtoForUpdate'e userin, username, email, phonenumber gibi bilgilerini aldik.
				userDto.Roles = new HashSet<string>(Roles.Select(r => r.Name).ToList()); //butun roller alindi 
				userDto.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user)); //userin rolleri alindi
				return userDto;
			}
			throw new Exception("An error occured.");
		}

		public async Task UpdateUserAsync(UserDtoForUpdate userDto)
		{
			var source = await GetOneUserAsync(userDto.UserName);
			var user = _mapper.Map<IdentityUser>(source);
			if (user != null)
			{
				var result = await _userManager.UpdateAsync(user);
				if (userDto.Roles.Count > 0)
				{
					var userRoles = await _userManager.GetRolesAsync(user);//updateden once userin ne kadar rolu varsa alalım
					var r1 = await _userManager.RemoveFromRolesAsync(user, userRoles);//burada da o rollerin hepsini kaldiralim
					var r2 = await _userManager.AddToRolesAsync(user, userDto.Roles); //rol tanimi, rol atamasi yapmadan mevcut rolleri kaldırıp oyle rol ekleme islemi yapiliyor
				}
				return;
			}
			throw new Exception("system has problem with user update");
		}
	}
}
