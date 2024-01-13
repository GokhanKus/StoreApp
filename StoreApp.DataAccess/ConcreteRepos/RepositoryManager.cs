using StoreApp.DataAccess.AbstractRepos;
using StoreApp.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.ConcreteRepos
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly StoreContext _context;
		private readonly ICategoryRepository _categoryRepository;
		private readonly IProductRepository _productRepository;
		public RepositoryManager(IProductRepository productRepository, StoreContext context, ICategoryRepository categoryRepository)
		{
			_context = context;
			_productRepository = productRepository;
			_categoryRepository = categoryRepository;
		}

		public IProductRepository Product => _productRepository;

		public ICategoryRepository Category => _categoryRepository;

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
