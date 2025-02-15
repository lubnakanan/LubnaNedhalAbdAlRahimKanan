using LubnaNedhalAbdAlRahimKanan.Models;

namespace LubnaNedhalAbdAlRahimKanan.Services
{
    public interface IVacationService
    {
        Task<IEnumerable<VacationRequest>> GetRequests();
        Task<VacationRequest?> GetRequest(int requestId);
        Task AddRequest(VacationRequest request);
        Task UpdateRequest(VacationRequest request);
        Task DeleteRequest(int requestId);
    }
}
