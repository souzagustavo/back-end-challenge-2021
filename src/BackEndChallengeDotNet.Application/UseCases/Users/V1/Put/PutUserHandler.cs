using AutoMapper;
using BackEndChallengeDotNet.Domain.Entities;
using BackEndChallengeDotNet.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BackEndChallengeDotNet.Application.UseCases.Users.V1.Put
{
    public class PutUserHandler : IRequestHandler<PutUserCommand, PutUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public PutUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<PutUserResponse> Handle(PutUserCommand request, CancellationToken cancellationToken)
        {
            var response = new PutUserResponse();

            if (string.IsNullOrWhiteSpace(request.UserId))
            {
                response.AddNotification(nameof(request.UserId), "Cannot be null or empty") ;
                return response;
            }

            var entityUser = _mapper.Map<User>(request.UserRequest);
            if (entityUser.IsInvalid)
            {
                response.AddNotifications(entityUser.Notifications);
                return response;
            }

            var IsAffeted = await _userRepository.ReplaceAsync(entityUser);
            if (!IsAffeted)
            {
                response.AddNotification("userId", "Not found", Notifications.ErrorCode.NotFound);
                return response;
            }

            return response;
        }
    }
}
