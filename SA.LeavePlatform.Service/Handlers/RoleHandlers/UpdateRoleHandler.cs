// UpdateRoleHandler.cs
using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.RoleRequests;
using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Handlers.RoleHandlers
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleRequest, Role?>
    {
        private readonly IRoleQueryRepository _repository;

        public UpdateRoleHandler(IRoleQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Role?> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
        {
            var role = await _repository.GetByIdAsync(request.Id);
            if (role == null)
                return null;

            role.Code = request.Code;
            role.Label = request.Label;
            role.Description = request.Description;

            // You'll need to add an update method to your repository
            await _repository.UpdateRoleAsync(role);
            return role;
        }
    }
}