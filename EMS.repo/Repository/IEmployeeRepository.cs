using EMS.core;
using EMS.core.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.repo.Repository
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        Task<IList<Employee>> GetAll(SearchEmployee searchEmployee);
    }
}
