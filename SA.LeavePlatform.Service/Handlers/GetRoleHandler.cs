//using MediatR;
//using SA.LeavePlatform.Domain.Entities;
//using SA.LeavePlatform.Service.Query;

//using System.Threading;
//using System.Threading.Tasks;

//namespace SA.LeavePlatform.Service.MediatRrequests.MediatRHandlers.Handlers
//{
//    public class GetRoleHandler : IRequestHandler<GetRoleRequest, Role?>
//    {
//        private readonly IRoleQueryRepository _repository;

//        public GetRoleHandler(IRoleQueryRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task<Role?> Handle(GetRoleRequest request, CancellationToken cancellationToken)
//        {
//            return await _repository.GetRoleByIdAsync(request.Id);
//        }
//    }
//}