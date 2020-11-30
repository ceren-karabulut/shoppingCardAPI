using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Case.Repository.Abstract
{
  public interface IBaseRepository <TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task<int> Add(TEntity entity);

        Task<int> SaveChanges();
    }
}
