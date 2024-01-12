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
		private readonly IProductRepository _productRepository;
		public RepositoryManager(IProductRepository productRepository, StoreContext context)
		{
			_context = context;
			_productRepository = productRepository;
		}

		public IProductRepository Product => _productRepository;

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
