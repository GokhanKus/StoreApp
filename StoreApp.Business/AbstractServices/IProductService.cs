﻿using StoreApp.Model.DTOs;
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
		IEnumerable<Product> GetAllProducts(bool trackChanges);
		IEnumerable<Product> GetShowCaseProducts(bool trackChanges);
		Product? GetOneProduct(int id, bool trackChanges);
		void CreateProduct(ProductDtoForInsertion productDto);
		void UpdateOneProduct(ProductDtoForUpdate productDto);
		void DeleteOneProduct(int id);
		ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
	}
}
