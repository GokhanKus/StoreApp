using Microsoft.EntityFrameworkCore;
using StoreApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.Context
{
	public class StoreContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public StoreContext(DbContextOptions<StoreContext> options) : base(options)
		{
			//default olan ctor yerine bunu yazdık ve
			//dbye baglanmak isteyen kullanici bize dbcontextoptions ifadesiyle gelecek ve biz bu optionsı alıp dbcontexte (base class) vermis olacagız
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Product>().HasData(
				new Product { Id = 1, CreatedTime = DateTime.Now, ProductName = "Laptop", Price = 30_000 },
				new Product { Id = 2, CreatedTime = DateTime.Now, ProductName = "Keyboard", Price = 1_000 },
				new Product { Id = 3, CreatedTime = DateTime.Now, ProductName = "Mouse", Price = 500 },
				new Product { Id = 4, CreatedTime = DateTime.Now, ProductName = "Monitor", Price = 5_000 },
				new Product { Id = 5, CreatedTime = DateTime.Now, ProductName = "Deck", Price = 1_500 }
				);

			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, CreatedTime = DateTime.Now, CategoryName = "Book" },
				new Category { Id = 2, CreatedTime = DateTime.Now, CategoryName = "Electronic" }
				);
		}
	}
}
//DataBase -> DBContext -> IRepositoryBase -> IProductRepository -> IRepositoryManager -> ProductController
//(ProductService?)
//IRepositoryBase ya da IGenericRepository temel (CRUD) islemlerin yapildiği genel bir classı temsil eder.