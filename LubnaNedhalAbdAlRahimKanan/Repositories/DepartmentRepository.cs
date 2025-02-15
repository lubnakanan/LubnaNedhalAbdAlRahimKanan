using LubnaNedhalAbdAlRahimKanan.Data;
using LubnaNedhalAbdAlRahimKanan.Models;
using Microsoft.EntityFrameworkCore;

namespace LubnaNedhalAbdAlRahimKanan.Repositories
{
    /// <summary>
    /// Implementation of the Department repository for database operations.
    /// </summary>
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department?> GetDepartmentById(int departmentId)
        {
            return await _context.Departments.FindAsync(departmentId);
        }

        public async Task AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartment(int departmentId)
        {
            var department = await _context.Departments.FindAsync(departmentId);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
        }
    }
}
