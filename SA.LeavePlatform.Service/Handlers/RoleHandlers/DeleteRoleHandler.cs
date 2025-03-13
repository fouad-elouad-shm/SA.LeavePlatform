// DeleteRoleHandler.cs
using MediatR;
using SA.LeavePlatform.Service.MediatRrequests.RoleRequests;
using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Handlers.RoleHandlers
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleRequest, bool>
    {
        private readonly IRoleQueryRepository _repository;

        public DeleteRoleHandler(IRoleQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteRoleRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteRoleAsync(request.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}