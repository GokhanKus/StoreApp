using StoreApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model.DTOs
{
	public record ProductDtoForInsertion : ProductDto
	{
		//product'ın ileride cok genisleyebilecegini dusundugumuz icin bu classı olusturduk
	}
}
