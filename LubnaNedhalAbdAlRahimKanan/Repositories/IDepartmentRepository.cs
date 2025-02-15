using LubnaNedhalAbdAlRahimKanan.Models;

namespace LubnaNedhalAbdAlRahimKanan.Repositories
{
    /// <summary>
    /// Interface defining operations for Department repository.
    /// </summary>
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department?> GetDepartmentById(int departmentId);
        Task AddDepartment(Department department);
        Task UpdateDepartment(Department department);
        Task DeleteDepartment(int departmentId);
    }
}
