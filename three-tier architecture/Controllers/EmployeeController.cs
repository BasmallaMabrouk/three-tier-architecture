using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using three_tier_architecture.BLL.Interfaces;
using three_tier_architecture.Models;

namespace three_tier_architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public IActionResult get(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid == true)
            {
                _employeeService.CreateEmployee(emp);
                return Ok();
            }

            else
            {
                return BadRequest(emp);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id ,Employee emp) { 
            if(emp.Id != null)
            {
               _employeeService.UpdateEmployee(emp);
                return Ok("Updated Sucssfully");
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
                return NotFound(new { Message = "Student not found" });

            _employeeService.DeleteEmployee(id);
            return NoContent();
        }

    }
}
