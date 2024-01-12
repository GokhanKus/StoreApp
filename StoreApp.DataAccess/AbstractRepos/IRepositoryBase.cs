using StoreApp.Model.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.AbstractRepos
{
	public interface IRepositoryBase<TEntity>
	{
		IQueryable<TEntity> FindAll(bool trackChanges);//EF Core'un performansini artirmak icin degisiklikleri izleyelim??(trackChanges)
		//IEnumerable<TEntity> FindAll(bool trackChanges);
		TEntity? FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges);
	}
}

/*Execution Strategy:

IEnumerable: LINQ sorgularını bellekte çalıştırır. Yani, veriler belleğe yüklenir ve ardından sorgular bu bellek içindeki veri üzerinde çalışır.
IQueryable: LINQ sorgularını veritabanında veya diğer uzak kaynaklarda çalıştırabilir. Sorgu, veritabanına dönüştürülebilir ve 
			yalnızca sonuçları çekmek için kullanılabilir. Bu, performans açısından daha etkili olabilir, 
			çünkü filtreleme ve sıralama gibi işlemler veritabanında gerçekleştirilebilir.

Filtering and Projection:

IEnumerable: Veri bellekte olduğu için, sorgular genellikle bellekteki tüm veri üzerinde çalışır. Yani, filtreleme veya projeksiyon işlemleri bellek içinde gerçekleşir.
IQueryable: Veritabanında çalıştırılabilen sorgular olduğu için, filtreleme ve projeksiyon gibi işlemler genellikle veritabanı tarafında gerçekleşir. Yani, yalnızca gerekli veri çekilir.

*/