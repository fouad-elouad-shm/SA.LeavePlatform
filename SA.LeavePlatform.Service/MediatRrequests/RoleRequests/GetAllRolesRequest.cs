using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.RoleRequests
{
    public class GetAllRolesRequest : IRequest<IEnumerable<Role>>
    {
    }
}
