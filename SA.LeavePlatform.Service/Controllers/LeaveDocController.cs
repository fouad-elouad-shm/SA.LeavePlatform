using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveDocController : ControllerBase
    {
        private readonly ILeaveDocQueryRepository _repository;
        public LeaveDocController(ILeaveDocQueryRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> AddLeaveDoc([FromBody] LeaveDoc leaveDoc)
        {
            
            await _repository.AddLeaveDocAsync(leaveDoc);
            // Ensure Role is not included when saving
            leaveDoc.LeaveRequest = null;
            

            return CreatedAtAction(nameof(GetAll), new { id = leaveDoc.Id }, leaveDoc);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveDoc(int id)
        {
            // Check if the status exists
            var leaveDoc = await _repository.GetByIdAsync(id);
            if (leaveDoc == null)
            {
                return NotFound(); // Return 404 if the status is not found
            }

            // Delete the status
            await _repository.DeleteLeaveDocAsync(id);

            // Return a 204 No Content response to indicate successful deletion
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var leaveDocs = await _repository.GetAllAsync();
            return Ok(leaveDocs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var leaveDoc = await _repository.GetByIdAsync(id);
            return Ok(leaveDoc);
        }
    }
}
