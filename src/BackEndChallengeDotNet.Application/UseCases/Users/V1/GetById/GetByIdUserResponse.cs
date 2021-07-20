using BackEndChallengeDotNet.Application.Notifications;
using BackEndChallengeDotNet.Application.ViewModels;
using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace BackEndChallengeDotNet.Application.UseCases.Users.V1.GetById
{
    public class GetByIdUserResponse : Result
    {
        public GetByIdUserResponse() : base(Enumerable.Empty<Notification>().ToList())
        {
        }

        public GetByIdUserResponse(IReadOnlyCollection<Notification> notifications) : base(notifications)
        {
        }

        public UserViewModel User { get; set; }
    }
}
