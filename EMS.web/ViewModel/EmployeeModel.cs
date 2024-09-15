using EMS.core;
using EMS.core.Query;

namespace EMS.web.ViewModel
{
    public class EmployeeModel:BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateOnly DOB { get; set; }
        public string? Mobile { get; set; }
        public string? Photo { get; set; }
        public IFormFile? PhotoPath { get; set; }
        public IList<Employee>? Employees { get; set;}
        public SearchEmployee SearchEmployee { get; set; }
       
    }
}
