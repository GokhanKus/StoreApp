using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.AbstractRepos;
using StoreApp.DataAccess.Context;
using StoreApp.Model.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

		public void Create(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);
		}
		public void Remove(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
		}

		public IQueryable<TEntity> FindAll(bool trackChanges)
		{
			return trackChanges ? _context.Set<TEntity>() //bu, bir liste geldi ve ef core listeyi izleyecek demek
				: _context.Set<TEntity>().AsNoTracking(); //ama eger degisiklikler izlenmeyecekse yine ilgili nesneye set olacagiz 
		}

		public TEntity? FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges)
		{
			return trackChanges
				? _context.Set<TEntity>().FirstOrDefault(expression)
				: _context.Set<TEntity>().AsNoTracking().FirstOrDefault(expression);

			//return trackChanges
			//	? _context.Set<TEntity>().Where(expression).SingleOrDefault()
			//	: _context.Set<TEntity>().Where(expression).AsNoTracking().SingleOrDefault();

			//Set<> : belirtliecek olan TEntity'nin örnegini kaydetmek icin ve sorgulama yapılabilecek bir entity icin dbset olusturulur
		}

	}
}
