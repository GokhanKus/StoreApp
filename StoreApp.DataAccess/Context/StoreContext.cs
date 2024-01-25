using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.Config;
using StoreApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.Context
{
	public class StoreContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Order> Orders { get; set; }
		//public DbSet<Order> Orders => Set<Order>();
		public StoreContext(DbContextOptions<StoreContext> options) : base(options)
		{
			//default olan ctor yerine bunu yazdık ve
			//dbye baglanmak isteyen kullanici bize dbcontextoptions ifadesiyle gelecek ve biz bu optionsı alıp dbcontexte (base class) vermis olacagız
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);
			//modelBuilder.ApplyConfiguration(new ProductConfig());  hazirladigimiz config(seeding) classlarını bu sekilde cagirabiiriz (1.yol)
			//modelBuilder.ApplyConfiguration(new CategoryConfig()); 

			//2.yol;
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//artik yeni tip kaydi yaptigimizda gelip burada onu tanimlamamiza gerek olmayacak, ilgili ifade dinamik olarak cozulecek.
			//Category tablomuzdaki "Id" alani primary keydir ve o column Product table'da "CategoryId" dir ve foreign keydir.
		}
	}
}
//DataBase -> DBContext -> IRepositoryBase -> IProductRepository -> IRepositoryManager -> Controller (servislerden sonra;)
//DataBase -> DBContext -> IRepositoryBase -> IProductRepository -> IRepositoryManager -> IProductService -> IServiceManager -> Controller

//IRepositoryBase ya da IGenericRepository temel (CRUD) islemlerin yapildiği genel bir classı temsil eder.