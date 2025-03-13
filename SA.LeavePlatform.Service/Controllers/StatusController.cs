using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusQueryRepository _repository;
        public StatusController(IStatusQueryRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> AddStatus([FromBody] Status status)
        {
            await _repository.AddStatusAsync(status);

            return CreatedAtAction(nameof(GetAll), new { id = status.Id }, status);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var statuses = await _repository.GetAllAsync();
            return Ok(statuses);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            // Check if the status exists
            var status = await _repository.GetByIdAsync(id);
            if (status == null)
            {
                return NotFound(); // Return 404 if the status is not found
            }

            // Delete the status
            await _repository.DeleteStatusAsync(id);

            // Return a 204 No Content response to indicate successful deletion
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var status = await _repository.GetByIdAsync(id);
            return Ok(status);
        }
    }
}
