using StoreApp.DataAccess.AbstractRepos;
using StoreApp.DataAccess.Context;
using StoreApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.ConcreteRepos
{
	public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
	{
		public CategoryRepository(StoreContext context) : base(context)
		{

		}
	}
}
