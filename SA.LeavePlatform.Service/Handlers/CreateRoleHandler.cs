//using MediatR;

//using SA.LeavePlatform.Service.Query;
//using System.Threading;
//using System.Threading.Tasks;

//namespace SA.LeavePlatform.Service.MediatRrequests.MediatRHandlers.Handlers
//{
//    public class CreateRoleHandler : IRequestHandler<CreateRoleRequest, int>
//    {
//        private readonly IRoleQueryRepository _repository;

//        public CreateRoleHandler(IRoleQueryRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task<int> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
//        {
//            // First validate the request
//            return await _repository.AddRoleAsync(request.Role);
//        }
//    }
//}