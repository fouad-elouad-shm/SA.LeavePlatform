using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestQueryRepository _repository;
        public LeaveRequestController(ILeaveRequestQueryRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> AddLeaveRequest([FromBody] LeaveRequest leaveRequest)
        {
           
            await _repository.AddLeaveRequestAsync(leaveRequest);
            // Ensure Role is not included when saving
            leaveRequest.Status = null;
            leaveRequest.LeaveType = null;
            leaveRequest.Employee = null;

            return CreatedAtAction(nameof(GetAll), new { id = leaveRequest.Id }, leaveRequest);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveRequest(int id)
        {
            // Check if the status exists
            var leaveRequest = await _repository.GetByIdAsync(id);
            if (leaveRequest == null)
            {
                return NotFound(); // Return 404 if the status is not found
            }

            // Delete the status
            await _repository.DeleteLeaveRequestAsync(id);

            // Return a 204 No Content response to indicate successful deletion
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var leaveRequests = await _repository.GetAllAsync();
            return Ok(leaveRequests);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var leaveRequest = await _repository.GetByIdAsync(id);
            return Ok(leaveRequest);
        }
    }
}
