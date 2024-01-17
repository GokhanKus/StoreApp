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

		public void CreateProduct(Product product)
		{
			//_manager.Product.Create(product); hangisini kullanmaliyiz? (2side sonuc olarak base repoya gidiyor.)
			_manager.Product.CreateOneProduct(product);
			_manager.Save();
		}

		public void DeleteOneProduct(int id)
		{
			Product? product = _manager.Product.GetOneProduct(id, false);
			if (product is not null)
			{
				_manager.Product.DeleteOneProduct(product);
				_manager.Save();
			}
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

		public void UpdateOneProduct(Product product)
		{
			//repository classlarında da tanımlamamıza gerek kalmadı, cunku ef core ilgili varligi izledigi icin bu ifadeleri dogrudan yerine getirmis oldu??
			var entity = _manager.Product.GetOneProduct(product.Id, true);
			if (entity != null)
			{
				entity.ProductName = product.ProductName;
				entity.Price = product.Price;
				entity.ModifiedTime = DateTime.Now;
			}
			_manager.Save();
		}
	}
}
