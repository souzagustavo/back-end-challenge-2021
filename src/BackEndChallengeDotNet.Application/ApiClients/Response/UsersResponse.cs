using BackEndChallengeDotNet.Application.DTOs;
using System.Collections.Generic;

namespace BackEndChallengeDotNet.Application.ApiClients.Response
{
    public class UsersResponse
    {
        public List<User> Results { get; set; }
    }
}
