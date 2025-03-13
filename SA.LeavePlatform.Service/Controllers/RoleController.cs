using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests;
using Microsoft.AspNetCore.Mvc;
using SA.LeavePlatform.Service.MediatRrequests.RoleRequests;

namespace MediatRAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllRoles()
        {
            var roles = await _mediator.Send(new GetAllRolesRequest());
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _mediator.Send(new GetRoleRequest { Id = id });

            if (role == null)
                return NotFound();

            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> CreateRole([FromBody] CreateRoleRequest request)
        {
            var createdRole = await _mediator.Send(request);

            if (createdRole == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetRole), new { id = createdRole.Id }, createdRole);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Role>> UpdateRole(int id, [FromBody] UpdateRoleRequest request)
        {
            if (id != request.Id)
                return BadRequest("ID mismatch");

            var updatedRole = await _mediator.Send(request);

            if (updatedRole == null)
                return NotFound();

            return Ok(updatedRole);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            var result = await _mediator.Send(new DeleteRoleRequest { Id = id });

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}