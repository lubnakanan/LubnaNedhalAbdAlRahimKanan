using LubnaNedhalAbdAlRahimKanan.Models;

namespace LubnaNedhalAbdAlRahimKanan.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee?> GetEmployee(string employeeNumber);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(string employeeNumber);
    }
}
