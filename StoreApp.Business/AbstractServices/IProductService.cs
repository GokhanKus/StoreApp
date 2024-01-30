using StoreApp.Model.DTOs;
using StoreApp.Model.Entities;
using StoreApp.Model.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Business.AbstractServices
{
	public interface IProductService
	{
		IEnumerable<Product> GetAllProducts(bool trackChanges);
		IEnumerable<Product> GetLastestProducts(int n, bool trackChanges);
		IEnumerable<Product> GetShowCaseProducts(bool trackChanges);
		IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
		Product? GetOneProduct(int id, bool trackChanges);
		void CreateProduct(ProductDtoForInsertion productDto);
		void UpdateOneProduct(ProductDtoForUpdate productDto);
		void DeleteOneProduct(int id);
		ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
	}
}
