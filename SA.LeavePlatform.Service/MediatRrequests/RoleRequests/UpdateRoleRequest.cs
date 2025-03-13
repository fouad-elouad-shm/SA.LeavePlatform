// UpdateRoleRequest.cs
using MediatR;
using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Service.MediatRrequests.RoleRequests
{
    public class UpdateRoleRequest : IRequest<Role?>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
    }
}