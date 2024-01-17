using StoreApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Business.AbstractServices
{
	public interface IProductService
	{
		public IEnumerable<Product> GetAllProducts(bool trackChanges);
		public Product? GetOneProduct(int id, bool trackChanges);
		public void CreateProduct(Product product);
		void UpdateOneProduct(Product product);
	}
}
