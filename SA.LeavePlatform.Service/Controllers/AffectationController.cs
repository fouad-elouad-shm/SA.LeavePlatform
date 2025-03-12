using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffectationController : ControllerBase
    {
        private readonly IAffectationQueryRepository _repository;
        public AffectationController(IAffectationQueryRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> AddAffectation([FromBody] Affectation affectation)
        {
            if (affectation == null || affectation.EmployeeId == 0 || affectation.ProjetId == 0)
            {
                return BadRequest("EmployeeId and ProjetId must be provided.");
            }
            await _repository.AddAffectationAsync(affectation);
            // Ensure Role is not included when saving
            affectation.Projet = null;
            affectation.Employee = null;

            return CreatedAtAction(nameof(GetAll), new { id = affectation.Id }, affectation);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAffectation(int id)
        {
            var affectation = await _repository.GetByIdAsync(id);
            if (affectation == null)
            {
                return NotFound(); // Return 404 if the status is not found
            }

            // Delete the status
            await _repository.DeleteAffectationAsync(id);

            // Return a 204 No Content response to indicate successful deletion
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var affectations = await _repository.GetAllAsync();
            return Ok(affectations);
        }
    }
}
