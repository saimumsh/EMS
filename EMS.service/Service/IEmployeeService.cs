using EMS.core;
using EMS.core.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace EMS.service.Service
{
    public interface IEmployeeService
    {
        Task<IList<Employee>> GetAll(SearchEmployee searchEmployee);
        Task<IPagedList<Employee>> GetAll(int pageNumber, int pageSize);
        Task<Employee> GetById(Guid id);
        Task<bool> Delete(Employee entity);
        Task Update(Employee entity);

        Task Add(Employee entity);
    }
}
