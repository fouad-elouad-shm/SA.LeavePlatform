// DeleteRoleRequest.cs
using MediatR;

namespace SA.LeavePlatform.Service.MediatRrequests.RoleRequests
{
    public class DeleteRoleRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}