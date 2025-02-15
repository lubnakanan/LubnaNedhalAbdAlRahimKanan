using LubnaNedhalAbdAlRahimKanan.Models;
using LubnaNedhalAbdAlRahimKanan.Repositories;

namespace LubnaNedhalAbdAlRahimKanan.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> GetEmployees() => await _repository.GetAllEmployees();

        public async Task<Employee?> GetEmployee(string employeeNumber) => await _repository.GetEmployeeById(employeeNumber);

        public async Task AddEmployee(Employee employee) => await _repository.AddEmployee(employee);

        public async Task UpdateEmployee(Employee employee) => await _repository.UpdateEmployee(employee);

        public async Task DeleteEmployee(string employeeNumber) => await _repository.DeleteEmployee(employeeNumber);
    }
}
