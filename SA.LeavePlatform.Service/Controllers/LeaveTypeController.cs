using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly ILeaveTypeQueryRepository _repository;
        public LeaveTypeController(ILeaveTypeQueryRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> AddLeaveType([FromBody] LeaveType leaveType)
        {
            await _repository.AddLeaveTypeAsync(leaveType);

            return CreatedAtAction(nameof(GetAll), new { id = leaveType.Id }, leaveType);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveType(int id)
        {
            // Check if the status exists
            var leaveType = await _repository.GetByIdAsync(id);
            if (leaveType == null)
            {
                return NotFound(); // Return 404 if the status is not found
            }

            // Delete the status
            await _repository.DeleteLeaveTypeAsync(id);

            // Return a 204 No Content response to indicate successful deletion
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var leaveTypes = await _repository.GetAllAsync();
            return Ok(leaveTypes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var leaveType = await _repository.GetByIdAsync(id);
            return Ok(leaveType);
        }
    }
}
