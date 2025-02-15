using LubnaNedhalAbdAlRahimKanan.Models;
using LubnaNedhalAbdAlRahimKanan.Services;
using Microsoft.AspNetCore.Mvc;

namespace LubnaNedhalAbdAlRahimKanan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationController : ControllerBase
    {
        private readonly IVacationService _vacationService;

        public VacationController(IVacationService vacationService)
        {
            _vacationService = vacationService;
        }

        // GET: api/Vacation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VacationRequest>>> GetVacationRequests()
        {
            var vacationRequests = await _vacationService.GetRequests();
            if (vacationRequests == null || !vacationRequests.Any())
            {
                return NotFound("No vacation requests found.");
            }
            return Ok(vacationRequests);
        }

        // GET: api/Vacation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VacationRequest>> GetVacationRequest(int id)
        {
            var vacationRequest = await _vacationService.GetRequest(id);
            if (vacationRequest == null)
            {
                return NotFound($"Vacation request with ID {id} not found.");
            }
            return Ok(vacationRequest);
        }

        // POST: api/Vacation
        [HttpPost]
        public async Task<ActionResult<VacationRequest>> CreateVacationRequest(VacationRequest vacationRequest)
        {
            if (vacationRequest == null)
            {
                return BadRequest("Invalid vacation request.");
            }

            await _vacationService.AddRequest(vacationRequest);
            return CreatedAtAction(nameof(GetVacationRequest), new { id = vacationRequest.RequestId }, vacationRequest);
        }

        // PUT: api/Vacation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVacationRequest(int id, VacationRequest vacationRequest)
        {
            if (id != vacationRequest.RequestId)
            {
                return BadRequest("Vacation request ID mismatch.");
            }

            var existingRequest = await _vacationService.GetRequest(id);
            if (existingRequest == null)
            {
                return NotFound($"Vacation request with ID {id} not found.");
            }

            await _vacationService.UpdateRequest(vacationRequest);
            return NoContent();
        }

        // DELETE: api/Vacation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacationRequest(int id)
        {
            var vacationRequest = await _vacationService.GetRequest(id);
            if (vacationRequest == null)
            {
                return NotFound($"Vacation request with ID {id} not found.");
            }

            await _vacationService.DeleteRequest(id);
            return NoContent();
        }
    }
}
