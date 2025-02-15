using LubnaNedhalAbdAlRahimKanan.Data;
using LubnaNedhalAbdAlRahimKanan.Models;
using Microsoft.EntityFrameworkCore;

namespace LubnaNedhalAbdAlRahimKanan.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeById(string employeeNumber)
        {
            return await _context.Employees.FindAsync(employeeNumber);
        }

        public async Task AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(string employeeNumber)
        {
            var employee = await _context.Employees.FindAsync(employeeNumber);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
