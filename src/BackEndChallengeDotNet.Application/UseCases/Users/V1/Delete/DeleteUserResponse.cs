using BackEndChallengeDotNet.Application.Notifications;
using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace BackEndChallengeDotNet.Application.UseCases.Users.V1.Delete
{
    public class DeleteUserResponse : Result
    {
        public DeleteUserResponse() : base(Enumerable.Empty<Notification>().ToList())
        {
        }

        public DeleteUserResponse(IReadOnlyCollection<Notification> notifications) : base(notifications)
        {
        }
    }
}
