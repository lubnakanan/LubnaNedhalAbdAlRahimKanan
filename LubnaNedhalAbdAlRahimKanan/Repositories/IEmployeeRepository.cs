using LubnaNedhalAbdAlRahimKanan.Models;

namespace LubnaNedhalAbdAlRahimKanan.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee?> GetEmployeeById(string employeeNumber);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(string employeeNumber);
    }
}
