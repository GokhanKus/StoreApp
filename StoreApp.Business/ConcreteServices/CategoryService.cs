using StoreApp.Business.AbstractServices;
using StoreApp.DataAccess.AbstractRepos;
using StoreApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Business.ConcreteServices
{
	//class adı CategoryManager da olabilirdi
	public class CategoryService : ICategoryService
	{
		private readonly IRepositoryManager _manager;

		public CategoryService(IRepositoryManager manager)
		{
			_manager = manager;
		}

		public IEnumerable<Category> GetAllCategories(bool trackChanges)
		{
			return _manager.Category.FindAll(trackChanges);
		}
	}
}
