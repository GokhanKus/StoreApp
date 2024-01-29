using Microsoft.EntityFrameworkCore;
using StoreApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.Extensions
{
	public static class ProductRepositoryExtension
	{
		public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products, int? categoryId) //genisletmek istedigimiz ifade product..
		{
			if (categoryId == null)
				return products;
			else
				return products.Where(p => p.CategoryId.Equals(categoryId));
		}
		public static IQueryable<Product> FilteredBySearchingTerm(this IQueryable<Product> products, string? SearchingTerm)
		{
			if (string.IsNullOrWhiteSpace(SearchingTerm))
				return products;
			else
				return products.Where(p => p.ProductName.ToLower().Contains(SearchingTerm.ToLower()));
		}
		public static IQueryable<Product> FilteredByPrice(this IQueryable<Product> products, int MinPrice, int MaxPrice, bool isValidPrice)
		{
			if (isValidPrice)
				return products.Where(p => p.Price >= MinPrice && p.Price <= MaxPrice);
			else
				return products;
		}
	}
}
