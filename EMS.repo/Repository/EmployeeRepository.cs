using EMS.core;
using EMS.core.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.repo.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IList<Employee>> GetAll(SearchEmployee searchEmployee)
        {
            var query = _db.Employees.AsQueryable();
            if (!string.IsNullOrEmpty(searchEmployee.SName))
            {
                query = query.Where(e => e.FirstName != null && e.FirstName.Contains(searchEmployee.SName));
            }
            if (!string.IsNullOrEmpty(searchEmployee.SEmail))
            {
                query = query.Where(e => e.Email != null && e.Email.Contains(searchEmployee.SEmail));
            } 
            if ((searchEmployee.SDOB)!=null)
            {
                query = query.Where(e => e.DOB.Equals(searchEmployee.SDOB));
            }
            if (!string.IsNullOrEmpty(searchEmployee.SMobile))
            {
                query = query.Where(e => e.Mobile != null && e.Mobile.Contains(searchEmployee.SMobile));
            }

            var result = await query.ToListAsync();
            return result;
        }
    }
}
