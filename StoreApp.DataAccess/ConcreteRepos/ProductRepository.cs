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
	public class ProductRepository : RepositoryBase<Product>, IProductRepository
	{
		public ProductRepository(StoreContext context) : base(context) //repositoryBase'in context'ini kullanalaım (ve o context de inject islemi ile db ile iletisimi saglacayacak.)
		{

		}
		public void CreateOneProduct(Product product) => Create(product);
		public void DeleteOneProduct(Product product) => Remove(product);
		public void UpdateOneProduct(Product entity) => Update(entity);
		public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);
		public IQueryable<Product> GetShowCaseProducts(bool trackChanges) => FindAll(trackChanges).Where(p => p.ShowCase.Equals(true));
		public Product? GetOneProduct(int id, bool trackChanges)
		{
			//return FindByCondition(p => p.Id == id, false);alttakiyle aynı
			return FindByCondition(p => p.Id.Equals(id), trackChanges);
		}
	}
}
