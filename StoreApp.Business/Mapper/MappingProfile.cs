using AutoMapper;
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
		}
	}
}
