using LubnaNedhalAbdAlRahimKanan.Models;
using LubnaNedhalAbdAlRahimKanan.Repositories;

namespace LubnaNedhalAbdAlRahimKanan.Services
{
    /// <summary>
    /// Implementation of the Department service, handling business logic.
    /// </summary>
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Department>> GetDepartments() => await _repository.GetAllDepartments();

        public async Task<Department?> GetDepartment(int departmentId) => await _repository.GetDepartmentById(departmentId);

        public async Task AddDepartment(Department department) => await _repository.AddDepartment(department);

        public async Task UpdateDepartment(Department department) => await _repository.UpdateDepartment(department);

        public async Task DeleteDepartment(int departmentId) => await _repository.DeleteDepartment(departmentId);
    }
}
