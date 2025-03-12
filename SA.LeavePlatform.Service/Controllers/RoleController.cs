using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleQueryRepository _repository;
        public RoleController(IRoleQueryRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] Role role)
        {
            await _repository.AddRoleAsync(role);

            return CreatedAtAction(nameof(GetAll), new { id = role.Id }, role);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _repository.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound(); // Return 404 if the status is not found
            }

            // Delete the status
            await _repository.DeleteRoleAsync(id);

            // Return a 204 No Content response to indicate successful deletion
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _repository.GetAllAsync();
            return Ok(roles);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _repository.GetByIdAsync(id);
            return Ok(role);
        }
    }
}
