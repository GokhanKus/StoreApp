using AutoMapper;
using StoreApp.Business.AbstractServices;
using StoreApp.DataAccess.AbstractRepos;
using StoreApp.Model.DTOs;
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
		private readonly IMapper _mapper;
		public ProductService(IRepositoryManager manager, IMapper mapper)
		{
			_manager = manager;
			_mapper = mapper;
		}

		public void CreateProduct(ProductDtoForInsertion productDto)
		{
			#region Auto Mapper'dan once
			//auto mapper kullanmazsak bu sekilde veri transferi yapariz, ancak proplar çok daha fazla olabilir ve her biri icin manuel yazmak zahmetli o yüzden auto mapper..
			//var product = new Product
			//{
			//	ProductName = productDto.ProductName,
			//	Price = productDto.Price,
			//	CategoryId = productDto.CategoryId,
			//};
			#endregion

			Product product = _mapper.Map<Product>(productDto); //auto mapper sayesinde ustteki gibi yazmak zorunda kalmadık.
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

		public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
		{
			var product = GetOneProduct(id, trackChanges);
			var productDto = _mapper.Map<ProductDtoForUpdate>(product);
			return productDto;
		}

		public void UpdateOneProduct(ProductDtoForUpdate productDto)
		{
			#region Auto mapper kullanmadan update
			//repository classlarında da tanımlamamıza gerek kalmadı, cunku ef core ilgili varligi izledigi icin bu ifadeleri dogrudan yerine getirmis oldu??
			//var entity = _manager.Product.GetOneProduct(productDto.Id, true);
			//if (entity != null)
			//{
			//	entity.ProductName = productDto.ProductName;
			//	entity.Price = productDto.Price;
			//	entity.CategoryId = productDto.CategoryId;
			//	entity.ModifiedTime = DateTime.Now;
			//	_manager.Save();
			//}
			#endregion
			var entity = _mapper.Map<Product>(productDto);
			_manager.Product.UpdateOneProduct(entity); 
			_manager.Save();
		}
	}
}
