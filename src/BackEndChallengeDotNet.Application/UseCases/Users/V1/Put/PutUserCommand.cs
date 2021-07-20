using MediatR;

namespace BackEndChallengeDotNet.Application.UseCases.Users.V1.Put
{
    public class PutUserCommand : IRequest<PutUserResponse>
    {
        public PutUserCommand(string userId, PutUserRequest userRequest)
        {
            UserRequest = userRequest;
        }

        public string UserId { get; set; }
        public PutUserRequest UserRequest { get; set; }
    }
}
