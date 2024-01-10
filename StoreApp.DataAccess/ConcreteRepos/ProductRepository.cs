﻿using StoreApp.DataAccess.AbstractRepos;
using StoreApp.DataAccess.Context;
using StoreApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.ConcreteRepos
{
	public class ProductRepository : RepositoryBase<Product>, IProductRepository
	{
		public ProductRepository(StoreContext context) : base(context) //repositoryBase'in context'ini kullanalaım (ve o context de inject islemi ile db ile iletisimi saglacayacak.)
		{

		}

		public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);
	}
}