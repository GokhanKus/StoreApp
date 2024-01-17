using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.Config
{
	public class ProductConfig : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			//entitynin id ismi "Id" veya "ProductId" ise coding conventiondan dolayı otomatik olarak ef core bunu primary key olarak atar,
			//eger farklı bir id ismi girmiş isek bu satırı yazabiliriz. ==> 

			builder.Property(p => p.ProductName).IsRequired(); //buna fluent api deniyor
			builder.Property(p => p.Price).IsRequired();
			builder.HasData(
				new Product { Id = 1, CategoryId = 1, CreatedTime = DateTime.Now, ProductName = "Laptop", Price = 30_000 },
					new Product { Id = 2, CategoryId = 1, CreatedTime = DateTime.Now, ProductName = "Keyboard", Price = 1_000 },
					new Product { Id = 3, CategoryId = 1, CreatedTime = DateTime.Now, ProductName = "Mouse", Price = 500 },
					new Product { Id = 4, CategoryId = 1, CreatedTime = DateTime.Now, ProductName = "Monitor", Price = 5_000 },
					new Product { Id = 5, CategoryId = 1, CreatedTime = DateTime.Now, ProductName = "Deck", Price = 1_500 },
					new Product { Id = 6, CategoryId = 2, CreatedTime = DateTime.Now, ProductName = "History", Price = 55 },
					new Product { Id = 7, CategoryId = 2, CreatedTime = DateTime.Now, ProductName = "Hamlet", Price = 45 }
				);
		}
	}
}
