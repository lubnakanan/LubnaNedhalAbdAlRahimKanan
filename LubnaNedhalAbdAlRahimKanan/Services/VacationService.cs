using LubnaNedhalAbdAlRahimKanan.Models;
using LubnaNedhalAbdAlRahimKanan.Repositories;

namespace LubnaNedhalAbdAlRahimKanan.Services
{
    public class VacationService : IVacationService
    {
        private readonly IVacationRepository _repository;

        public VacationService(IVacationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<VacationRequest>> GetRequests() => await _repository.GetAllRequests();

        public async Task<VacationRequest?> GetRequest(int requestId) => await _repository.GetRequestById(requestId);

        public async Task AddRequest(VacationRequest request) => await _repository.AddRequest(request);

        public async Task UpdateRequest(VacationRequest request) => await _repository.UpdateRequest(request);

        public async Task DeleteRequest(int requestId) => await _repository.DeleteRequest(requestId);
    }
}
