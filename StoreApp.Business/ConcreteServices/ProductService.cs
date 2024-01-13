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
	//class adı ProductManager da olabilir, ben ProductService yaptım.
	public class ProductService : IProductService
	{
		private readonly IRepositoryManager _manager;

		public ProductService(IRepositoryManager manager)
		{
			_manager = manager;
		}

		public IEnumerable<Product> GetAllProducts(bool trackChanges)
		{
			return _manager.Product.GetAllProducts(trackChanges);
		}

		public Product? GetOneProduct(int id, bool trackChanges)
		{
			var product = _manager.Product.GetOneProduct(id, trackChanges);
			if (product is null)
			{
				throw new Exception("Product not found");
			}
			return product;
		}
	}
}
