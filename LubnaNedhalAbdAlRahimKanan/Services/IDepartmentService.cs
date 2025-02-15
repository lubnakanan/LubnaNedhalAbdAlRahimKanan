using LubnaNedhalAbdAlRahimKanan.Models;

namespace LubnaNedhalAbdAlRahimKanan.Services
{
    /// <summary>
    /// Interface defining operations for Department service.
    /// </summary>
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department?> GetDepartment(int departmentId);
        Task AddDepartment(Department department);
        Task UpdateDepartment(Department department);
        Task DeleteDepartment(int departmentId);
    }
}
