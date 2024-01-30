using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.AbstractRepos;
using StoreApp.DataAccess.Context;
using StoreApp.DataAccess.Extensions;
using StoreApp.Model.Entities;
using StoreApp.Model.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.ConcreteRepos
{
	//sealed: bu classin bir daha devralinamayacagini belirtiri bu classin son versiyonudur inherit edilmesi artik mumkun degildir.
	public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
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

		public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
		{
			return _context.Products
				.FilteredByCategoryId(p.CategoryId)
				.FilteredBySearchingTerm(p.SearchingTerm)
				.FilteredByPrice(p.MinPrice, p.MaxPrice, p.IsValidPrice)
				.ToPaginate(p.PageNumber, p.PageSize);
		}
	}
}
