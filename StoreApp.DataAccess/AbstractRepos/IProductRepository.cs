using StoreApp.Model.BaseEntities;
using StoreApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.AbstractRepos
{
	public interface IProductRepository:IRepositoryBase<Product>
	{
		IQueryable<Product> GetAllProducts(bool trackChanges);
		public Product? GetOneProduct(int id, bool trackChanges);
	}
}
