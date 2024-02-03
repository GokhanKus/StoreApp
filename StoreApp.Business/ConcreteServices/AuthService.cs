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
					throw new Exception("system have probmlems with roles");
			}
			return result;
		}

		public IEnumerable<IdentityUser> GetAllUsers()
		{
			return _userManager.Users.ToList();
		}
	}
}
