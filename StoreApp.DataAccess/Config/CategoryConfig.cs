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
	public class CategoryConfig : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Property(c => c.CategoryName).IsRequired();//fluent api
			builder.HasData(
				new Category { Id = 1, CreatedTime = DateTime.Now, CategoryName = "Book" },
				new Category { Id = 2, CreatedTime = DateTime.Now, CategoryName = "Electronic" }
				);
		}
	}
}
