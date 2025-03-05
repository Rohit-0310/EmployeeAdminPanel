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

        [HttpPatch("{id}")]
        public IActionResult UpdateEmployee(Guid id, [FromBody] UpdateEmployeedto updateEmployee)
        {
            var employee = dbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound("Employee Not Found....");
            }
            if(!string.IsNullOrEmpty(updateEmployee.Name))
                employee.Name = updateEmployee.Name;

            if(!string.IsNullOrEmpty (updateEmployee.Email))
                employee.Email = updateEmployee.Email;

            if(!string.IsNullOrEmpty(updateEmployee.Phone))
                employee.Phone = updateEmployee.Phone;

            if(updateEmployee.Salary.HasValue)
                employee.Salary = updateEmployee.Salary.Value;

            dbContext.SaveChanges();
            return Ok(employee);
        }

        


    }
}
