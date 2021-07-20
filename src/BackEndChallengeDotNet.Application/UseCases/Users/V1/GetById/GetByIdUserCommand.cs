using MediatR;

namespace BackEndChallengeDotNet.Application.UseCases.Users.V1.GetById
{
    public class GetByIdUserCommand : IRequest<GetByIdUserResponse>
    {
        public GetByIdUserCommand(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}
