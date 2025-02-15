using LubnaNedhalAbdAlRahimKanan.Models;
using LubnaNedhalAbdAlRahimKanan.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LubnaNedhalAbdAlRahimKanan.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // Get all employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeService.GetEmployees();
            if (employees == null)
            {
                return NotFound("No employees found.");
            }
            return Ok(employees);
        }

        // Get a specific employee by employee number
        [HttpGet("{employeeNumber}")]
        public async Task<ActionResult<Employee>> GetEmployee(string employeeNumber)
        {
            var employee = await _employeeService.GetEmployee(employeeNumber);
            if (employee == null)
            {
                return NotFound($"Employee with number {employeeNumber} not found.");
            }
            return Ok(employee);
        }

        // Create a new employee
        [HttpPost]
        public async Task<ActionResult> CreateEmployee(Employee employee)
        {
            // You might want to validate the employee input here before saving
            await _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployee), new { employeeNumber = employee.EmployeeNumber }, employee);
        }

        // Update an existing employee
        [HttpPut("{employeeNumber}")]
        public async Task<ActionResult> UpdateEmployee(string employeeNumber, Employee employee)
        {
            if (employeeNumber != employee.EmployeeNumber)
            {
                return BadRequest("Employee number mismatch.");
            }

            var existingEmployee = await _employeeService.GetEmployee(employeeNumber);
            if (existingEmployee == null)
            {
                return NotFound($"Employee with number {employeeNumber} not found.");
            }

            await _employeeService.UpdateEmployee(employee);
            return NoContent();
        }

        // Delete an employee
        [HttpDelete("{employeeNumber}")]
        public async Task<ActionResult> DeleteEmployee(string employeeNumber)
        {
            var existingEmployee = await _employeeService.GetEmployee(employeeNumber);
            if (existingEmployee == null)
            {
                return NotFound($"Employee with number {employeeNumber} not found.");
            }

            await _employeeService.DeleteEmployee(employeeNumber);
            return NoContent();
        }
    }
}
