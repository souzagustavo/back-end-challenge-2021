using MediatR;

namespace BackEndChallengeDotNet.Application.UseCases.Users.V1.GetList
{
    public class GetListUserCommand : IRequest<GetListUserResponse>
    {
        public GetListUserCommand(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
