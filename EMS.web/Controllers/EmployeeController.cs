using EMS.core;
using EMS.core.Query;
using EMS.repo.Repository;
using EMS.service.Service;
using EMS.web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.Extensions;


namespace EMS.web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employee;
        private readonly IWebHostEnvironment webHostEnvironment;
        public EmployeeController(IEmployeeService employee, IWebHostEnvironment webHostEnvironment)
        {
            _employee = employee;
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index(SearchEmployee searchEmployee)
        {
            // Initialize EmployeeModel and SearchEmployee if they are null
            var EmployeeModel = new EmployeeModel(); 
            
            // Get employees based on the search criteria
            var Employees = await _employee.GetAll(searchEmployee);
            EmployeeModel.Employees = Employees;

            // Return the view with the populated EmployeeModel
            return View(EmployeeModel);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeModel obj)
        {
            if (ModelState.IsValid)
            {
                var path = webHostEnvironment.WebRootPath;
                var filePath = "image/" + obj.PhotoPath.FileName;
                var fullPath = Path.Combine(path, filePath);
                FileUpload(obj.PhotoPath, fullPath);

                Employee employee = new Employee()
                {
                    FirstName = obj.FirstName,
                    LastName = obj.LastName,
                    Email = obj.Email,
                    DOB = obj.DOB,
                    Mobile = obj.Mobile,
                    Photo = filePath,

                };
                await _employee.Add(employee);
                return RedirectToAction("index", "Employee");
            }
            else
            {
                return View(obj);
            }

        }
        public void FileUpload(IFormFile file, string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Create);
            file.CopyTo(fileStream);
        }
        public async Task<IActionResult> Update(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee obj = await _employee.GetById(id);
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Employee obj)
        {

            if (ModelState.IsValid && obj.PhotoPath != null)
            {
                var path = webHostEnvironment.WebRootPath;
                var filePath = "image/" + obj.PhotoPath.FileName;
                var fullPath = Path.Combine(path, filePath);
                FileUpload(obj.PhotoPath, fullPath);
                obj.Photo = filePath;
                await _employee.Update(obj);
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                await _employee.Update(obj);
                return RedirectToAction("Index", "Employee");
            }
        }      
        public async Task<IActionResult> Delete(Guid id)
        {
            var obj = await _employee.GetById(id);
            var result = await _employee.Delete(obj);
            return Json(result);
        }
    }

}

