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
				new Product { Id = 1, CategoryId = 2, ImageUrl = "1.jpg", ProductName = "Laptop", Price = 30_000, ShowCase = false, CreatedTime = DateTime.Now },
				new Product { Id = 2, CategoryId = 2, ImageUrl = "2.jpg", ProductName = "Keyboard", Price = 1_000, ShowCase = false, CreatedTime = DateTime.Now },
				new Product { Id = 3, CategoryId = 2, ImageUrl = "3.jpg", ProductName = "Mouse", Price = 500, ShowCase = false, CreatedTime = DateTime.Now },
				new Product { Id = 4, CategoryId = 2, ImageUrl = "4.jpg", ProductName = "Monitor", Price = 5_000, ShowCase = false, CreatedTime = DateTime.Now },
				new Product { Id = 5, CategoryId = 2, ImageUrl = "5.jpg", ProductName = "Deck", Price = 1_500, ShowCase = false, CreatedTime = DateTime.Now },
				new Product { Id = 6, CategoryId = 1, ImageUrl = "6.jpg", ProductName = "Guns, Germs and Steel", Price = 165, ShowCase = false, CreatedTime = DateTime.Now },
				new Product { Id = 7, CategoryId = 1, ImageUrl = "7.jpg", ProductName = "1984", Price = 45, ShowCase = false, CreatedTime = DateTime.Now },
				new Product { Id = 8, CategoryId = 2, ImageUrl = "8.jpg", ProductName = "Xp-Pen", Price = 450, ShowCase = true, CreatedTime = DateTime.Now },
				new Product { Id = 9, CategoryId = 2, ImageUrl = "9.jpg", ProductName = "Galaxy FE", Price = 15000, ShowCase = true, CreatedTime = DateTime.Now },
				new Product { Id = 10, CategoryId = 2, ImageUrl = "10.jpg", ProductName = "Hp Mouse", Price = 400, ShowCase = true, CreatedTime = DateTime.Now }
				);
		}
	}
}
