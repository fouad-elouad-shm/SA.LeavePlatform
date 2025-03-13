// GetAllRolesHandler.cs
using MediatR;
using SA.LeavePlatform.Domain.Entities;
using SA.LeavePlatform.Service.MediatRrequests.RoleRequests;
using SA.LeavePlatform.Service.Query;

namespace SA.LeavePlatform.Service.Handlers.RoleHandlers
{
    public class GetAllRolesHandler : IRequestHandler<GetAllRolesRequest, IEnumerable<Role>>
    {
        private readonly IRoleQueryRepository _repository;

        public GetAllRolesHandler(IRoleQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Role>> Handle(GetAllRolesRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}