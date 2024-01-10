using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Infrastructure.Abstract
{
    public interface IRepositoryBase<TEntity>
    {
        IQueryable<TEntity> FindAll(bool trackChanges);//EF Core'un performansini artirmak icin degisiklikleri izleyelim??(trackChanges)
    }
}
