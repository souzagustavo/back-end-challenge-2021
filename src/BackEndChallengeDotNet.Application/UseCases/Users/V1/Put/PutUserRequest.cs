using BackEndChallengeDotNet.Application.DTOs;
using BackEndChallengeDotNet.Domain.Enums;

namespace BackEndChallengeDotNet.Application.UseCases.Users.V1.Put
{
    public class PutUserRequest : User
    {
        public EUserStatus Status { get; set; }
    }
}
