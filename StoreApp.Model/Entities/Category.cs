using StoreApp.Model.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model.Entities
{
	public class Category : BaseEntity
	{
		public string? CategoryName { get; set; } = string.Empty;
    }
}
