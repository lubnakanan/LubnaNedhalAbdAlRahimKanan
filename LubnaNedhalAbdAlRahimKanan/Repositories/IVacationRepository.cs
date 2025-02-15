using LubnaNedhalAbdAlRahimKanan.Models;

namespace LubnaNedhalAbdAlRahimKanan.Repositories
{
    public interface IVacationRepository
    {
        Task<IEnumerable<VacationRequest>> GetAllRequests();
        Task<VacationRequest?> GetRequestById(int requestId);
        Task AddRequest(VacationRequest request);
        Task UpdateRequest(VacationRequest request);
        Task DeleteRequest(int requestId);
    }
}
