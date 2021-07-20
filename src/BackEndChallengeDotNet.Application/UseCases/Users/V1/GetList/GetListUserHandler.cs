using AutoMapper;
using BackEndChallengeDotNet.Application.ViewModels;
using BackEndChallengeDotNet.Domain.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackEndChallengeDotNet.Application.UseCases.Users.V1.GetList
{
    public class GetListUserHandler : IRequestHandler<GetListUserCommand, GetListUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetListUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetListUserResponse> Handle(GetListUserCommand request, CancellationToken cancellationToken)
        {
            var response = new GetListUserResponse();

            var (total, results) = await _userRepository.GetAllPagedAsync(request.PageSize, request.PageNumber);

            if (!results.Any())
                return response;

            var viewModels = _mapper.Map<UserViewModel[]>(results);
            response.Total = total;
            response.Users = viewModels;

            return response;
        }
    }
}
