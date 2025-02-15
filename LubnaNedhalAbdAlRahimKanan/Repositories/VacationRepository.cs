using LubnaNedhalAbdAlRahimKanan.Data;
using LubnaNedhalAbdAlRahimKanan.Models;
using Microsoft.EntityFrameworkCore;

namespace LubnaNedhalAbdAlRahimKanan.Repositories
{
    public class VacationRepository : IVacationRepository
    {
        private readonly AppDbContext _context;

        public VacationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VacationRequest>> GetAllRequests()
        {
            return await _context.VacationRequests.ToListAsync();
        }

        public async Task<VacationRequest?> GetRequestById(int requestId)
        {
            return await _context.VacationRequests.FindAsync(requestId);
        }

        public async Task AddRequest(VacationRequest request)
        {
            _context.VacationRequests.Add(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRequest(VacationRequest request)
        {
            _context.VacationRequests.Update(request);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRequest(int requestId)
        {
            var request = await _context.VacationRequests.FindAsync(requestId);
            if (request != null)
            {
                _context.VacationRequests.Remove(request);
                await _context.SaveChangesAsync();
            }
        }
    }
}
