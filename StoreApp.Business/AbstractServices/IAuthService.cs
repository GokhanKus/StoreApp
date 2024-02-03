﻿using Microsoft.AspNetCore.Identity;
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
		Task<IdentityResult> CreateUserAsync(UserDtoForCreation userDto);
	}
}
 