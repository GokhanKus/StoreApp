using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StoreApp.Model.DTOs;
using StoreApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Business.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<ProductDtoForInsertion, Product>(); //dtodan product'a veriler maplenecek
			CreateMap<ProductDtoForUpdate, Product>().ReverseMap();

			CreateMap<UserDtoForCreation, IdentityUser>();
			CreateMap<UserDtoForUpdate, IdentityUser>();
			CreateMap<UserDtoForUpdate, IdentityUser>().ReverseMap();
			//sourceden destinationa ama update islemi yaptigimiz icin veriyi cekerken veriyi goruntulemek icin producttan ProductDtoForUpdateya veri maplememiz lazım yani reverse.
		}
	}
}
