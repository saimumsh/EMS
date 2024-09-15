using EMS.core;
using EMS.core.Query;
using EMS.repo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace EMS.service.Service
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _db;
        public EmployeeService(IEmployeeRepository db)
        {
            _db = db;
        }
        public async Task Add(Employee entity)
        {
            await _db.Add(entity);
        }

        public async Task<bool> Delete(Employee entity)
        {
            return await _db.Delete(entity);

        }
        public async Task<IList<Employee>> GetAll(SearchEmployee searchEmployee)
        {
            return await _db.GetAll(searchEmployee);
        }
        public async Task<IPagedList<Employee>> GetAll(int pageNumber, int pageSize)
        {
            return await _db.GetAll(pageNumber, pageSize);
        }

        public async Task<Employee> GetById(Guid id)
        {
            return await _db.GetById(id);

        }
        public async Task Update(Employee entity)
        {
            await _db.Update(entity);
        }
    }
}
