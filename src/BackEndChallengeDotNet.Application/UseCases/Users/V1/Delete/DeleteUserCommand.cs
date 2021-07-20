using MediatR;

namespace BackEndChallengeDotNet.Application.UseCases.Users.V1.Delete
{
    public class DeleteUserCommand : IRequest<DeleteUserResponse>
    {
        public DeleteUserCommand(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}
