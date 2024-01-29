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
	}
}
