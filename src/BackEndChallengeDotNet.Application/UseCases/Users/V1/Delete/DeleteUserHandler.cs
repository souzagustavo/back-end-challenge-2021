using BackEndChallengeDotNet.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BackEndChallengeDotNet.Application.UseCases.Users.V1.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteUserResponse();

            if (string.IsNullOrWhiteSpace(request.UserId))
            {
                response.AddNotification(nameof(request.UserId), "Cannot be null or empty");
                return response;
            }

            var deleted = await _userRepository.DeleteAsync(request.UserId);
            if (!deleted)
            {
                response.AddNotification(nameof(request.UserId), "Not found", Notifications.ErrorCode.NotFound);
                return response;
            }

            return response;
        }
    }
}
