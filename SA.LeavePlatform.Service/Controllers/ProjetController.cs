using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetController : ControllerBase
    {
        private readonly IProjetQueryRepository _repository;
        public ProjetController(IProjetQueryRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> AddProjet([FromBody] Projet projet)
        {
            await _repository.AddProjetAsync(projet);

            return CreatedAtAction(nameof(GetAll), new { id = projet.Id }, projet);
        }
        [HttpDelete("{id}")]    
        public async Task<IActionResult> DeleteProjet(int id)
        {
            var projet = await _repository.GetByIdAsync(id);
            if (projet == null)
            {
                return NotFound(); // Return 404 if the status is not found
            }

            // Delete the status
            await _repository.DeleteProjetAsync(id);

            // Return a 204 No Content response to indicate successful deletion
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projets = await _repository.GetAllAsync();
            return Ok(projets);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var projet = await _repository.GetByIdAsync(id);
            return Ok(projet);
        }
    }
}
