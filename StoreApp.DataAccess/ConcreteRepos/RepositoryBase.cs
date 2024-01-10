using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.AbstractRepos;
using StoreApp.DataAccess.Context;
using StoreApp.Model.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.ConcreteRepos
{
	public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity, new()
	{
		protected readonly StoreContext _context; //ben bu contexti devraldigim(kalitim) classlarda da kullanabilmek istedigim icin private yerine protected yaptım.
		protected RepositoryBase(StoreContext context)
		{
			_context = context;
		}
		public IQueryable<TEntity> FindAll(bool trackChanges)
		{
			return trackChanges ? _context.Set<TEntity>() //bu, bir liste geldi ve ef core listeyi izleyecek demek
				: _context.Set<TEntity>().AsNoTracking(); //ama eger degisiklikler izlenmeyecekse yine ilgili nesneye set olacagiz 
		}
	}
}
