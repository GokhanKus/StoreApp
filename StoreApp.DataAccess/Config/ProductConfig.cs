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
				new Product { Id = 1, CategoryId = 2, ImageUrl = "1.jpg", ProductName = "Laptop", Price = 30_000, CreatedTime = DateTime.Now },
				new Product { Id = 2, CategoryId = 2, ImageUrl = "2.jpg", ProductName = "Keyboard", Price = 1_000, CreatedTime = DateTime.Now },
				new Product { Id = 3, CategoryId = 2, ImageUrl = "3.jpg", ProductName = "Mouse", Price = 500, CreatedTime = DateTime.Now },
				new Product { Id = 4, CategoryId = 2, ImageUrl = "4.jpg", ProductName = "Monitor", Price = 5_000, CreatedTime = DateTime.Now },
				new Product { Id = 5, CategoryId = 2, ImageUrl = "5.jpg", ProductName = "Deck", Price = 1_500, CreatedTime = DateTime.Now },
				new Product { Id = 6, CategoryId = 1, ImageUrl = "6.jpg", ProductName = "Guns, Germs and Steel", Price = 165, CreatedTime = DateTime.Now },
				new Product { Id = 7, CategoryId = 1, ImageUrl = "7.jpg", ProductName = "1984", Price = 45, CreatedTime = DateTime.Now }
				);
		}
	}
}
