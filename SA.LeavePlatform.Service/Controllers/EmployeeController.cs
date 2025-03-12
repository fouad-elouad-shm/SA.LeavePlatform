using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Infrastructure;

using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeQueryRepository _repository;
        public EmployeeController(IEmployeeQueryRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            await _repository.AddEmployeeAsync(employee);
            // Ensure Role is not included when saving
            employee.Role = null;

            return CreatedAtAction(nameof(GetAll), new { id = employee.Id }, employee);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound(); // Return 404 if the status is not found
            }

            // Delete the status
            await _repository.DeleteEmployeeAsync(id);

            // Return a 204 No Content response to indicate successful deletion
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _repository.GetAllAsync();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound(); // Retourne 404 si l'employé n'est pas trouvé
            }

            return Ok(employee); // Retourne l'employé avec le statut 200 OK
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Employee updatedEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingEmployee = await _repository.GetByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound("Employee not found");
            }

            // Mettre à jour uniquement les champs nécessaires (sans toucher à l'ID)
            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.LastName = updatedEmployee.LastName;
            existingEmployee.Phone = updatedEmployee.Phone;
            existingEmployee.Email = updatedEmployee.Email;

            existingEmployee.RoleId = updatedEmployee.RoleId;

            await _repository.UpdateAsync(existingEmployee);
            return NoContent(); // 204 No Content pour indiquer une mise à jour réussie
        }

    }
}
