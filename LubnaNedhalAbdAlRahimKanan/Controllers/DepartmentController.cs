using LubnaNedhalAbdAlRahimKanan.Models;
using LubnaNedhalAbdAlRahimKanan.Services;
using Microsoft.AspNetCore.Mvc;

namespace LubnaNedhalAbdAlRahimKanan.Controllers
{
    /// <summary>
    /// Controller to manage department-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        /// <summary>
        /// Get all departments.
        /// </summary>
        /// <returns>List of departments.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await _departmentService.GetDepartments();
            return Ok(departments);
        }

        /// <summary>
        /// Get a specific department by ID.
        /// </summary>
        /// <param name="id">Department ID.</param>
        /// <returns>The department with the given ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _departmentService.GetDepartment(id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        /// <summary>
        /// Add a new department.
        /// </summary>
        /// <param name="department">The department to be added.</param>
        /// <returns>Action result.</returns>
        [HttpPost]
        public async Task<ActionResult<Department>> AddDepartment(Department department)
        {
            if (department == null)
            {
                return BadRequest();
            }

            await _departmentService.AddDepartment(department);

            return CreatedAtAction(nameof(GetDepartment), new { id = department.DepartmentId }, department);
        }

        /// <summary>
        /// Update an existing department.
        /// </summary>
        /// <param name="id">Department ID.</param>
        /// <param name="department">Updated department details.</param>
        /// <returns>Action result.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, Department department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

            var existingDepartment = await _departmentService.GetDepartment(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }

            await _departmentService.UpdateDepartment(department);
            return NoContent();
        }

        /// <summary>
        /// Delete a department by ID.
        /// </summary>
        /// <param name="id">Department ID.</param>
        /// <returns>Action result.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _departmentService.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }

            await _departmentService.DeleteDepartment(id);
            return NoContent();
        }
    }
}
