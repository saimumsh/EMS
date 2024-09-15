using EMS.core.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace EMS.repo.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAll();
        Task<IPagedList<T>> GetAll(int pageNumber, int pageSize);
        Task<T> GetById(Guid id);
        Task<bool> Delete(T entity);
        Task Update(T entity);
       
        Task Add(T entity);
    }
}
