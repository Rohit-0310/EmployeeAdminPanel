using EmployeeAdminPanel.Data;
using EmployeeAdminPanel.Models;
using EmployeeAdminPanel.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPanel.Controllers
{
    //localhoat:xxxx/api/employee
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public EmployeeController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            var allEmployee = dbContext.Employees.ToList();
            return Ok(allEmployee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeedto addEmployeedto)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeedto.Name,
                Email = addEmployeedto.Email,
                Phone = addEmployeedto.Phone,
                Salary = addEmployeedto.Salary
            };
            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();
            return Ok(employeeEntity);
        }
    }
}
