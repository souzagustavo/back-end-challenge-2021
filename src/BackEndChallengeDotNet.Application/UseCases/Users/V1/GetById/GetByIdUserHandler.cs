using AutoMapper;
using BackEndChallengeDotNet.Application.ViewModels;
using BackEndChallengeDotNet.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BackEndChallengeDotNet.Application.UseCases.Users.V1.GetById
{
    public class GetByIdUserHandler : IRequestHandler<GetByIdUserCommand, GetByIdUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetByIdUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdUserResponse> Handle(GetByIdUserCommand request, CancellationToken cancellationToken)
        {
            var response = new GetByIdUserResponse();

            if (string.IsNullOrWhiteSpace(request.UserId))
            {
                response.AddNotification(nameof(request.UserId), "Cannot be null or empty");
                return response;
            }

            var userFound = await _userRepository.GetAsync(entityId: request.UserId);
            if (userFound == null)
            {
                response.AddNotification(nameof(request.UserId), "Not found", Notifications.ErrorCode.NotFound);
                return response;
            }

            response.User = _mapper.Map<UserViewModel>(userFound);
            return response;
        }
    }
}
