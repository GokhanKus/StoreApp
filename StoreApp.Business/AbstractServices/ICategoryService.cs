using StoreApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Business.AbstractServices
{
	public interface ICategoryService
	{
		public IEnumerable<Category> GetAllCategories(bool trackChanges);
	}
}
