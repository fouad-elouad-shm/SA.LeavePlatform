// CreateRoleHandler.cs
using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.RoleRequests;
using SA.LeavePlatform.Service.Query;
using System.Threading;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Service.Handlers.RoleHandlers
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleRequest, Role?>
    {
        private readonly IRoleQueryRepository _repository;

        public CreateRoleHandler(IRoleQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Role?> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
        {
            var role = new Role
            {
                Code = request.Code,
                Label = request.Label,
                Description = request.Description
            };

            await _repository.AddRoleAsync(role);
            return role;
        }
    }
}