using EMS.core.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EMS.repo.Repository
{
    public class Repository<T>:IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public async Task Add(T entity)
        {
            await Task.Run(() =>
            {
                _db.Add(entity);
                _db.SaveChangesAsync();
            });
           

        }

        public async Task<bool> Delete(T entity)
        {
            await Task.Run(() =>
            {
                _db.Remove(entity);
               
            });
           return await _db.SaveChangesAsync()>0;

        }
        public virtual async Task<IList<T>> GetAll()
        {
            var obj = await _db.Set<T>().ToListAsync();
            return obj;
        }


        public async Task<IPagedList<T>> GetAll(int pageNumber, int pageSize)
        {
            var list = await _db.Set<T>().ToListAsync();
            return list.ToPagedList(pageNumber,pageSize);
        }

        public async Task<T> GetById(Guid id)
        {
            var obj = await _db.Set<T>().FindAsync(id);
            return obj;

        }

        public async Task Update(T entity)
        {
            await Task.Run(() => 
            {
                _db.Update(entity);
                _db.SaveChangesAsync();
            });
            
        }
    }
}
